using System;
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
    public class VATTUsController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: VATTUs
        public ActionResult Index()
        {
            return View(db.VATTUs.ToList());
        }

        // GET: VATTUs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VATTU vATTU = db.VATTUs.Find(id);
            if (vATTU == null)
            {
                return HttpNotFound();
            }
            return View(vATTU);
        }

        // GET: VATTUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VATTUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVatTu,TenVatTu,SoLuong,DonGia")] VATTU vATTU)
        {
            if (ModelState.IsValid)
            {
                db.VATTUs.Add(vATTU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vATTU);
        }

        // GET: VATTUs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VATTU vATTU = db.VATTUs.Find(id);
            if (vATTU == null)
            {
                return HttpNotFound();
            }
            return View(vATTU);
        }

        // POST: VATTUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVatTu,TenVatTu,SoLuong,DonGia")] VATTU vATTU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vATTU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vATTU);
        }

        // GET: VATTUs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VATTU vATTU = db.VATTUs.Find(id);
            if (vATTU == null)
            {
                return HttpNotFound();
            }
            return View(vATTU);
        }

        // POST: VATTUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VATTU vATTU = db.VATTUs.Find(id);
            db.VATTUs.Remove(vATTU);
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
