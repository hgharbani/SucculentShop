using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Web.Security;
using DataLayer.ViewModel;
using MyEshop;

namespace SucculentShop.Controllers
{
    public class AccountController : Controller
    {
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            using(var db=new MyEshop_DbEntities())
            {
                if (!db.Users.Any(a => a.Email.ToLower() == registerViewModel.Email.Trim().ToLower()))
                {
                    User user = new User()
                    {
                        UserName = registerViewModel.UserName.Trim().ToLower(),
                        Email=registerViewModel.Email.Trim().ToLower(),
#pragma warning disable CS0618 // Type or member is obsolete
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(registerViewModel.Password, "MD5"),
#pragma warning restore CS0618 // Type or member is obsolete
                        ActiveCode = Guid.NewGuid().ToString(),
                        RoleId = 1,
                        IsActive = false,
                        RegisterDate = DateTime.Now
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    //Send Active Email
                    var body = PartialToStringClass.RenderPartialView("ManageEmail", "ActivetionEmail", user);
                     SendEmail.Send(user.Email, "فعال سازی حساب", body);
                    //end Active Email
                    return View("SuccessRegister", user);
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربر تکراری می باشد");
                    return View(registerViewModel);
                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Login")]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <param name="ReturnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login")]
        public ActionResult Login(LoginViewModel loginViewModel,string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {
                using (var db = new MyEshop_DbEntities())
                {
                    var passwordHashCode =
                        FormsAuthentication.HashPasswordForStoringInConfigFile(loginViewModel.Password, "MD5");
                    var user = db.Users.SingleOrDefault(a =>
                        a.Email.ToLower() == loginViewModel.Email.Trim().ToLower() && a.Password == passwordHashCode);
                    if (user != null)
                    {
                        if (user.IsActive)
                        {
                            FormsAuthentication.SetAuthCookie(user.UserName, loginViewModel.RememberMe);
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            ModelState.AddModelError("Email", "حساب کاربری فعال نمی باشد");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "کاربری با اطلاعات فوق یافت نشد");
                    }
                }


            }

            return View();
        }

        public ActionResult ActiveUser(string id)
        {
            using (var db=new MyEshop_DbEntities())
            {
                var user = db.Users.SingleOrDefault(a => a.ActiveCode == id);
                if (user == null)
                {
                    HttpNotFound();
                }

                user.IsActive = true;
                user.ActiveCode = Guid.NewGuid().ToString();
                db.SaveChanges();
                return View(user);
            }
        }

        [Route("ForgetPassword")]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetPassword(ForgetPasswordViewModel model)
        {
            return View();

        }
        public ActionResult DeleteAccount()
        {
            return View();

        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Login");
        }
    }
}