using AssignmentASPdotNet.CMS22.Services;
using AssignmentASPdotNet.CMS22.ViewModels;
using AssignmentASPdotNet.CMS22.ViewModels.Home;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentASPdotNet.CMS22.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;
        private readonly ShowcaseService _showcaseService;

        public HomeController(ProductService productService, ShowcaseService showcaseService)
        {
            _productService = productService;
            _showcaseService = showcaseService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Products = await _productService.GetProducts();
            viewModel.Showcase = await _showcaseService.GetLatestShowcase();

            ViewData["Title"] = "Home";
            return View(viewModel);
        }
    }
}
