using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameStarz.Models;

namespace GameStarz
{
    public class LoginAndRegisterController:Controller
    {
        private DatabaseContext dbContext;
        public LoginAndRegisterController(DatabaseContext context)
        {
            dbContext = context;
        }
        
        [HttpGet("")]
        [HttpGet("LoginAndRegister")]
        public IActionResult LoginAndRegister(){

            return View("LoginAndRegister");
        }

        [HttpGet("logout")]
        public IActionResult logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("LoginAndRegister");
        }

        [HttpPost("registration_process")]
        public IActionResult register_process(LogAndRegUserBundle bundle){
            var user=bundle.register_user;
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(theuser=>theuser.email==user.email))
                {
                    ModelState.AddModelError("register_user.email","Email already Exist");
                    return View("LoginAndRegister");
                }

                var hasher=new PasswordHasher<User>();
                user.password=hasher.HashPassword(user,user.password);
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("user_id",(int)user.user_id);

                return RedirectToAction("Home","Dashboard");
            }

            return View("LoginAndRegister");
        }


        [HttpPost("login_process")]
        public IActionResult login_process(LogAndRegUserBundle bundle){
            var login_user=bundle.login_user;
            if (ModelState.IsValid)
            {
                var databaseUser=dbContext.Users.FirstOrDefault(theloginUser=>theloginUser.email==login_user.LoginEmail);
                if (databaseUser!=null)
                {
                    var hasher=new PasswordHasher<LoginUser>();
                    var result=hasher.VerifyHashedPassword(login_user,databaseUser.password,login_user.LoginPassword);
                    if (result!=0)
                    {
                        HttpContext.Session.SetInt32("user_id",(int)databaseUser.user_id);
                        return RedirectToAction("Home","Dashboard");
                    }

                    ModelState.AddModelError("login_user.LoginEmail","Invalid Email or Password");
                    return View("LoginAndRegister");

                }

                ModelState.AddModelError("login_user.LoginEmail","Invalid Email or Password");
                return View("LoginAndRegister");
                
            }

            return View("LoginAndRegister");
        }

    }
}