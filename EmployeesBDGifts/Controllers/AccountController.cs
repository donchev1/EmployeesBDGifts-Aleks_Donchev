using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EmployeesBDGifts.Data.Repos;
using EmployeesBDGifts.Models;
using EmployeesBDGifts.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using EmployeesBDGifts.Data;

namespace EmployeesBDGifts.Controllers
{
    public class AccountController : Controller
    {
        public IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<User> users;
            users = _userRepository.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (_userRepository.UserExistsByUserName(model.UserName))
            {
                ViewBag.errorMessage = "UserName taken.";
                return View(model);
            }
            var user = new User
            {
                Name = model.Name,
                UserName = model.UserName,
                Bday = model.Bday,
                Password = model.Password
            };

            _userRepository.CreateUser(user);
            _userRepository.SaveChanges();
            TempData["SuccessMessage"] = "Registration complete.";
            return RedirectToAction("Index", "Home"); ;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userRepository.GetUserByUserNameAndPassword(model.UserName, model.Password);
            bool userExists = user != null;

            if (userExists)
            {
                ClaimsPrincipal principal = new ClaimsPrincipal();

                List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };

                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                principal = new ClaimsPrincipal(userIdentity);

                if (model.RememberMe)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                    new AuthenticationProperties { IsPersistent = true });
                }
                else
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                    new AuthenticationProperties { IsPersistent = false });
                }
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.errorMessage = "User name or password wrong. Please try again. *";
            return View("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View("Error");
        }

    }
}