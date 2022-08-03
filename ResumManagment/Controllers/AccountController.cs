using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResumManagment.Models;
using ResumManagment.ViewModel;

namespace ResumManagment.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> singinmanager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.usermanager = userManager;
            this.singinmanager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await singinmanager.SignOutAsync();
            return RedirectToAction("index", "Resum");
        }
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Register() 
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid) 
            {
                var user = new ApplicationUser
                { 
                   UserName = register.Email,
                   Email = register.Email,
                   City = register.City
                };
                var result = await usermanager.CreateAsync(user, register.Password);

                var model1 = result;

                if (model1.Succeeded)
                {
                   var model = singinmanager;
                   await model.SignInAsync(user, isPersistent: false);

                    return  RedirectToAction("index", "Resum");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            } 
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login()
        {
            return View();
        }
        [AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await usermanager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");   
            }
        }
            [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await singinmanager.PasswordSignInAsync(login.Email, login.Password, login.rememberMe, false);

                if (result.Succeeded)
                {
                    //if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    //{
                    //    return LocalRedirect(returnUrl);
                    //}
                    //else
                    //{
                       
                    //}
                    return RedirectToAction("index", "Resum");

                }
                    ModelState.AddModelError(string.Empty, "Invalid login Attempt");
            }
            return View(login);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
