using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.EF_Models;
using IStore_WEB_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IStore_WEB_.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = new User() { Email = model.Login, UserName = model.Login };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        if (ReturnUrl == "/")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }

                        }
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            return new EmptyResult();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.IsRememberMe, false);

                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        if (ReturnUrl == "/")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }

                        }
                    }
                }
                else
                {
                    return Json("USER NOT FOUND");
                }
            }

            return Json("MODEL NO VALID");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Logout(string ReturnUrl = "")
        {
            await _signInManager.SignOutAsync();

            if (!String.IsNullOrEmpty(ReturnUrl))
            {
                if (ReturnUrl == "/")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                }
            }

            //todo redirect error page 
            return new EmptyResult();
        }

    }
}