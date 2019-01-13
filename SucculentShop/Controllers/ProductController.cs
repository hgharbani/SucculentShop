using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace SucculentShop.Controllers
{
    public class ProductController : Controller
    {
        MyEshop_DbEntities db=new MyEshop_DbEntities();
        // GET: Product
        public ActionResult ShowGroups()
        {
            return PartialView(db.Product_Group.ToList());
        }
    }
}