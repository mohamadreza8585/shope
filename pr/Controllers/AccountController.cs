using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using BLL;
using BEE;
using Microsoft.AspNetCore.Authorization;



namespace pr.Controllers
{
    public class AccountController:Controller
    {

        private IWebHostEnvironment _Environment;

        private UserManager<User> userManager;
        private SignInManager<User> signInManager;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _Environment = webHostEnvironment;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Models.model.user model)
        {

            var user = await userManager.FindByNameAsync(model.username);
            if (user == null)
            {
                ModelState.AddModelError("", "نام کاربری و رمز عبور وجود ندارد");
                return View(model);
            }
            var Result = await signInManager.PasswordSignInAsync(user, model.password, true, false);
            if (!Result.Succeeded)
            {

                ModelState.AddModelError("", "نام کاربری و رمز عبور مطابقت ندارد");
                return View(model);

            }
            return RedirectToAction("Index", "Home");


        }
        [Authorize]
        public async Task<IActionResult> logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            //if (User.Identity.IsAuthenticated)
            //{
            //    await signInManager.SignOutAsync();
            //    return RedirectToAction("Index", "Home");

            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}

        }
        public async Task<IActionResult> Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Models.model.user usermodel)
        {  
            var existuser1 = userManager.FindByNameAsync(usermodel.username);
            if (usermodel.name == null | usermodel.family == null | usermodel.email == null | usermodel.password == null | usermodel.passwordconfirm == null | usermodel.username == null)
            {
                ModelState.AddModelError("", "لطفا همه فیلد هارا پر کنید");
                return View(usermodel);
            }
           
            else if (usermodel.password != usermodel.passwordconfirm)
            {
                ModelState.AddModelError("", "رمز عبور خود را تایید کنید");
                return View(usermodel);
            }
            else
            {
                var new_user = new User {

                    name = usermodel.name,
                    family = usermodel.family,
                    Email = usermodel.email,
                    UserName = usermodel.username
                
               };
               
                var result1 = await userManager.CreateAsync(new_user,usermodel.password);
                
                if (result1.Succeeded)
                {
                     return RedirectToAction("Login", "Account");

                }
                else
                {
                    ModelState.AddModelError("", result1.Errors.ToString());
                    return View(usermodel);
                }
            }
            
        }   
    }

}
