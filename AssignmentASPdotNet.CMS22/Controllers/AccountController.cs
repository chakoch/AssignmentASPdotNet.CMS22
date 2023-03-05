using AssignmentASPdotNet.CMS22.Contexts;
using AssignmentASPdotNet.CMS22.Models.Entities;
using AssignmentASPdotNet.CMS22.Models.Forms;
using AssignmentASPdotNet.CMS22.Models.Identity;
using AssignmentASPdotNet.CMS22.Services;
using AssignmentASPdotNet.CMS22.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentityContext _identityContext;
        private readonly ProfileHandler _profileHandler;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IdentityContext identityContext, ProfileHandler profileHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _identityContext = identityContext;
            _profileHandler = profileHandler;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AccountIndexViewModel();
            var appUser = await _userManager.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);

            if (appUser != null)
            {
                viewModel.Profile = new UserAccount
                {
                    UserId = appUser.Id,
                    FirstName = appUser.Profile.FirstName,
                    LastName = appUser.Profile.LastName,
                    Email = appUser.Email!,
                    StreetName = appUser.Profile.StreetName!,
                    PostalCode = appUser.Profile.PostalCode!,
                    City = appUser.Profile.City!
                };
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit()
        {
            var viewModel = new AccountEditViewModel();
            var appUser = await _userManager.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);

            if (appUser != null)
            {
                viewModel.UserId = appUser.Id;
                viewModel.Form = new ProfileEditForm
                {
                    FirstName = appUser.Profile.FirstName,
                    LastName = appUser.Profile.LastName,
                    StreetName = appUser.Profile.StreetName!,
                    PostalCode = appUser.Profile.PostalCode!,
                    City = appUser.Profile.City!
                };
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccountEditViewModel viewModel)
        {
            var appUser = await _userManager.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);
            var userProfileEntity = await _identityContext.UserProfileEntities.FirstOrDefaultAsync(x => x.Id == appUser!.ProfileId);

            if (userProfileEntity != null)
            {
                userProfileEntity.FirstName = viewModel.Form.FirstName;
                userProfileEntity.LastName = viewModel.Form.LastName;
                userProfileEntity.StreetName = viewModel.Form.StreetName;
                userProfileEntity.PostalCode = viewModel.Form.PostalCode;
                userProfileEntity.City = viewModel.Form.City;

                _identityContext.Update(userProfileEntity);
                await _identityContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");

        }







        [AllowAnonymous]
        public IActionResult Register(string ReturnUrl = null!)
        {
            var viewModel = new RegisterViewModel();
            viewModel.ReturnUrl = ReturnUrl ?? Url.Content("/");

            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl = null!)
        {
            var viewModel = new LoginViewModel();
            viewModel.ReturnUrl = ReturnUrl ?? Url.Content("/");

            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {


            if (ModelState.IsValid)
            {
                var userRole = "User";

                if (!await _roleManager.Roles.AnyAsync() && !await _userManager.Users.AnyAsync())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("Product Manager"));
                    await _roleManager.CreateAsync(new IdentityRole("User"));

                    userRole = "Admin";
                }

                if (await _userManager.Users.AnyAsync(x => x.Email == viewModel.Form.Email))
                {
                    ModelState.AddModelError(string.Empty, "A user with the same email adress already exists.");
                    return View(viewModel);
                }

                var userProfileEntity = new UserProfileEntity
                {
                    FirstName = viewModel.Form.FirstName,
                    LastName = viewModel.Form.LastName,
                    StreetName = viewModel.Form.StreetName,
                    PostalCode = viewModel.Form.PostalCode,
                    City = viewModel.Form.City
                };

                _identityContext.Add(userProfileEntity);

                var appUser = new AppUser
                {
                    Email = viewModel.Form.Email,
                    UserName = viewModel.Form.Email,
                    ProfileId = userProfileEntity.Id,

                };

                var userManager = new UserManager<AppUser>(new UserStore<AppUser>(_identityContext), null!, null!, null!, null!, null!, null!, null!, null!);
                var result = await userManager.CreateAsync(appUser, viewModel.Form.Password);


                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, userRole);

                    var signInResult = await _signInManager.PasswordSignInAsync(appUser, viewModel.Form.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                        
                        if(viewModel.Form.ProfileImage != null)
                        {
                            userProfileEntity.ImageName = await _profileHandler.UploadProfileImageAsync(viewModel.Form.ProfileImage);
                        }
                        
                        return LocalRedirect(viewModel.ReturnUrl!);
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                _identityContext.Add(userProfileEntity);
                await _identityContext.SaveChangesAsync();



            }

            ModelState.AddModelError(string.Empty, "Unable to create an Account.");
            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, false, false);
                if (signInResult.Succeeded)
                    return LocalRedirect(viewModel.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View(viewModel);
        }

        public async Task<IActionResult> LoggOut()
        {
            await _profileHandler.LoggOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
