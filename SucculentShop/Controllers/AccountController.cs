using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Web.Security;
using DataLayer.ViewModel;
namespace SucculentShop.Controllers
{
    public class AccountController : Controller
    {
      
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
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
                        IsActive = true,
                        RegisterDate = DateTime.Now
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    return View("SuccessRegister", user);
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربر تکراری می باشد");
                    return View(registerViewModel);
                }
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult EditAccount()
        {
            return View();

        }
        public ActionResult RecoveryAccount()
        {
            return View();

        }
        public ActionResult DeleteAccount()
        {
            return View();

        }
    }
}