using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebsiteMovies.Models;
using WebsiteMovies.ViewModel;
using WebsiteMovies.WebServises;

namespace WebsiteMovies.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // this is interface
        private UserManager<ApplicationUser> userManger;
        private SignInManager<ApplicationUser> signinManger;

        public AccountController(UserManager<ApplicationUser> user,SignInManager<ApplicationUser> signinManger )
        {
            this.signinManger = signinManger;
            this.userManger = user;
        }
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUserVm userVm)
        {



            if (ModelState.IsValid)
            {
                //mapping
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userVm.userName,
                    Email = userVm.email,
                    Address = userVm.Address,
                };

                var CheckUserExist = userManger.Users
                    .FirstOrDefault(e=>e.Email==user.Email);

                if (CheckUserExist!=null)
                {
                    return View();
                }
              
           
                var result = await userManger.CreateAsync(user, userVm.Password);

                if (result.Succeeded)
                {
                    //Cookie
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        if (error.Code.Contains("Password"))
                        {
                            ModelState.AddModelError(nameof(userVm.Password), 
                                "Password Must Be Strong");
                        }
                        else if (error.Code.Contains("Email"))
                        {
                            ModelState.AddModelError(nameof(userVm.email)
                                , error.Description);
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }

                }
            }
            return View();
        }


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVm userVm)
        {
            if (ModelState.IsValid)
            {
                var user = await userManger.FindByNameAsync(userVm.userName);

                if (user!=null)
                {
                    var check = await userManger.
                        CheckPasswordAsync(user,userVm.Password);
                     Console.WriteLine("enter");

                    if (!check)
                    {
                        ModelState.
                       AddModelError("Password", "Password Not Correct");
                        return View();
                    }
                    await signinManger.SignInAsync(user, userVm.rememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.
                        AddModelError("userName","User Name Not Found");
                    return View();
                }
            }

            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {

            await signinManger.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
