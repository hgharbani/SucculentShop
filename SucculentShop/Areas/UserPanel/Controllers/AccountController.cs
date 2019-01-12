using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataLayer;
using DataLayer.ViewModel;

namespace SucculentShop.Areas.UserPanel.Controllers
{
    public class AccountController : Controller
    {
        MyEshop_DbEntities db=new MyEshop_DbEntities();
        // GET: UserPanel/Account
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel change)
        {
            if (ModelState.IsValid)
            {
                var oldPasswordHashCode = FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "MD5");
                var user = db.Users.SingleOrDefault(a => a.UserName == User.Identity.Name );

                if (user.Password == oldPasswordHashCode)
                {
                    user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");
                    db.SaveChanges();
                    ViewBag.Success = true;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "اطلاعات همخانی ندارد");
                }
            }
            return View();
        }
    }
}