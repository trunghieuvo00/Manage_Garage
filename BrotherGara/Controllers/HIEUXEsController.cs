﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrotherGara.Models;

namespace BrotherGara.Controllers
{
    public class HIEUXEsController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: HIEUXEs
        public ActionResult Index()
        {
            return View(db.HIEUXEs.ToList());
        }

        // GET: HIEUXEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIEUXE hIEUXE = db.HIEUXEs.Find(id);
            if (hIEUXE == null)
            {
                return HttpNotFound();
            }
            return View(hIEUXE);
        }

        // GET: HIEUXEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIEUXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHieuXe,TenHieuXe")] HIEUXE hIEUXE)
        {
            if (ModelState.IsValid)
            {
                db.HIEUXEs.Add(hIEUXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hIEUXE);
        }

        // GET: HIEUXEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIEUXE hIEUXE = db.HIEUXEs.Find(id);
            if (hIEUXE == null)
            {
                return HttpNotFound();
            }
            return View(hIEUXE);
        }

        // POST: HIEUXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHieuXe,TenHieuXe")] HIEUXE hIEUXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hIEUXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hIEUXE);
        }

        // GET: HIEUXEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIEUXE hIEUXE = db.HIEUXEs.Find(id);
            if (hIEUXE == null)
            {
                return HttpNotFound();
            }
            return View(hIEUXE);
        }

        // POST: HIEUXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HIEUXE hIEUXE = db.HIEUXEs.Find(id);
            db.HIEUXEs.Remove(hIEUXE);
            db.SaveChanges();
            return RedirectToAction("Index");
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
