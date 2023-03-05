using AssignmentASPdotNet.CMS22.ViewModels.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentASPdotNet.CMS22.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var indexViewModel = new IndexViewModel();
            return View(indexViewModel);
        }

        //[Authorize(Roles = "Admin, Product Owner")]
        //public IActionResult AddProduct()
        //{

        //}
    }
}
