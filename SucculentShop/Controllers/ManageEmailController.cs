﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SucculentShop.Controllers
{
    public class ManageEmailController : Controller
    {
        // GET: ManageEmail
        public ActionResult ActivetionEmail()
        {
            return PartialView();
        }

        public ActionResult RecoveryPassword()
        {
            return PartialView();
        }
    }
}