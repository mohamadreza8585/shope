using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEE;
using Microsoft.AspNetCore.Hosting;
using BLL;
namespace webstor.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment Environment;
       
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        
        public AccountController (UserManager<User> userManager, SignInManager<User> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            Environment = webHostEnvironment;
        }
        public IActionResult Rigester()
        {

            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Rigester(Models.model.user usermodel)
        {
            var bluser= new bluser();
            var new_user = new User();
            var existuser = userManager.FindByNameAsync(usermodel.username);
            if (usermodel.name == null | usermodel.family == null | usermodel.email == null | usermodel.password == null | usermodel.passwordconfirm == null | usermodel.username == null)
            {
                ModelState.AddModelError("", "لطفا همه فیلد هارا پر کنید");
                return View(usermodel);
            }
            else if (existuser!=null)
            {
                ModelState.AddModelError("", "نام کاربری قبلا ثبت شده است");
                return View(usermodel);
            }
            else if (usermodel.password!=usermodel.passwordconfirm)
            {
                ModelState.AddModelError("", "رمز عبور خود را تایید کنید");
                return View(usermodel);
            }
            else {
               
                new_user.name = usermodel.name;
                new_user.family = usermodel.family;
                new_user.Email = usermodel.email;
                new_user.PasswordHash = usermodel.password;
                var result = await userManager.CreateAsync(new_user, usermodel.passwordconfirm);
                ModelState.AddModelError("", "اطلاعات شما ثبت گردید");
                
            }
            return View();


        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Models.model.user model)
        {
            
            var user =await userManager.FindByNameAsync(model.username);
            if (user == null)
            {
                ModelState.AddModelError("", "نام کاربری و رمز عبور وجود ندارد");
                return View(model);
            }
            var Result = signInManager.PasswordSignInAsync(user, model.password, true, false);
            if (!Result.IsCompletedSuccessfully)
            {
                ModelState.AddModelError("", "نام کاربری و رمز عبور مطابقت ندارد");
                return View(model);
            }
            return View();

        }
        public IActionResult Accessdinid()
        {
            return View();
        }
    }
}
