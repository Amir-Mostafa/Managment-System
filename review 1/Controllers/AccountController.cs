using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using review_1.Models;
using Microsoft.AspNetCore.Identity;
using review_1.BL.helper;
namespace review_1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> manager;

        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> manager, SignInManager<IdentityUser> signInManager)
        {
            this.manager = manager;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(ModelState.IsValid)
            {
                var result=await signInManager.PasswordSignInAsync(model.Email, model.Password, model.rememberMe,false);

                if(result.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "invalid username or password");
                }
            }
            return View(model);
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() {
                    UserName = model.Email,
                    Email = model.Email
                };
             var result= await manager.CreateAsync(user, model.Password);
               if(result.Succeeded)
                {
                    return RedirectToAction("login");
                }
               else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                        
                    }
                    return View(model);
                }
            }
            else
                return View(model);
        }
        public IActionResult ForegetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForegetPassword(ForgetPasswordVM forgetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await manager.FindByEmailAsync(forgetPassword.Email);

                if (user != null)
                {
                    var token = await manager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = forgetPassword.Email, Token = token }, Request.Scheme);

                    Mail.SendMail("Reset Palssword Link", passwordResetLink,forgetPassword.Email);
                    return RedirectToAction("ConformForgetPassword");
                }
                ModelState.AddModelError("","this mail not register");
                return View(forgetPassword);
            }

            return View(forgetPassword);
        }

        public IActionResult ConformForgetPassword()
        {
            return View();
        }
        public IActionResult ResetPassword(string Email,string Token)
        {
            if(Email==null||Token==null)
            {
                ModelState.AddModelError("", "Invalid Data");
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetpassword)
        {
            if (ModelState.IsValid)
            {
                var user = await manager.FindByEmailAsync(resetpassword.Email);

                if (user != null)
                {
                    var result = await manager.ResetPasswordAsync(user, resetpassword.Token, resetpassword.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConformResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(resetpassword);
                }

                return RedirectToAction("ConformResetPassword");
            }

            return View(resetpassword);
        }

        public IActionResult ConformResetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
