﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace SucculentShop.Areas.Admin.Controllers
{
    public class Product_GroupController : Controller
    {
        private MyEshop_DbEntities db = new MyEshop_DbEntities();

        // GET: Admin/Product_Group
        public ActionResult Index()
        {
            var product_Group = db.Product_Group.Where(a => a.ParentId == null);
            return View(product_Group.ToList());
        }

        public ActionResult ListGroups()
        {
            var product_Group = db.Product_Group.Where(a => a.ParentId == null);
            return PartialView(product_Group.ToList());
        }

        // GET: Admin/Product_Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product_Group product_Group = db.Product_Group.Find(id);
            if (product_Group == null)
            {
                return HttpNotFound();
            }

            return View(product_Group);
        }

        // GET: Admin/Product_Group/Create
        public ActionResult Create(int? id)
        {
            return PartialView(new Product_Group()
            {
                ParentId = id
            });
        }

        // POST: Admin/Product_Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupTitle,ParentId")]
            Product_Group product_Group)
        {
            if (ModelState.IsValid)
            {
                db.Product_Group.Add(product_Group);
                db.SaveChanges();
                return PartialView("ListGroups", db.Product_Group.Where(a => a.ParentId == null).ToList());
            }

            ViewBag.ParentId = new SelectList(db.Product_Group, "GroupId", "GroupTitle", product_Group.ParentId);
            return PartialView(product_Group);
        }

        // GET: Admin/Product_Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product_Group product_Group = db.Product_Group.Find(id);
            if (product_Group == null)
            {
                return HttpNotFound();
            }

            ViewBag.ParentId = new SelectList(db.Product_Group, "GroupId", "GroupTitle", product_Group.ParentId);
            return PartialView(product_Group);
        }

        // POST: Admin/Product_Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupTitle,ParentId")]
            Product_Group product_Group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Group).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("ListGroups", db.Product_Group.Where(a => a.ParentId == null).ToList());
            }

            return View(product_Group);
        }

        
        public void Delete(int id)
        {
            Product_Group product_Group = db.Product_Group.Find(id);
            if (product_Group != null)
            {
                if (!product_Group.Product_Group1.Any())
                {
                    db.Product_Group.Remove(product_Group);
                }
                else
                {
                    foreach (var productGroup in product_Group.Product_Group1.ToList())
                    {
                        db.Entry(productGroup).State = EntityState.Deleted;
                    }

                    db.Product_Group.Remove(product_Group);
                }

                db.SaveChanges();
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}