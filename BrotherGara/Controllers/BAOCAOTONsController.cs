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
    public class BAOCAOTONsController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: BAOCAOTONs
        public ActionResult Index()
        {
            var bAOCAOTONs = db.BAOCAOTONs.Include(b => b.VATTU);
            return View(bAOCAOTONs.ToList());
        }

        // GET: BAOCAOTONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOTON bAOCAOTON = db.BAOCAOTONs.Find(id);
            if (bAOCAOTON == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAOTON);
        }

        // GET: BAOCAOTONs/Create
        public ActionResult Create()
        {
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu");
            return View();
        }

        // POST: BAOCAOTONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVatTu,MaTN,TonDau,PhatSinh,TonCuoi")] BAOCAOTON bAOCAOTON)
        {
            if (ModelState.IsValid)
            {
                db.BAOCAOTONs.Add(bAOCAOTON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", bAOCAOTON.MaVatTu);
            return View(bAOCAOTON);
        }

        // GET: BAOCAOTONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOTON bAOCAOTON = db.BAOCAOTONs.Find(id);
            if (bAOCAOTON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", bAOCAOTON.MaVatTu);
            return View(bAOCAOTON);
        }

        // POST: BAOCAOTONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVatTu,MaTN,TonDau,PhatSinh,TonCuoi")] BAOCAOTON bAOCAOTON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAOCAOTON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaVatTu = new SelectList(db.VATTUs, "MaVatTu", "TenVatTu", bAOCAOTON.MaVatTu);
            return View(bAOCAOTON);
        }

        // GET: BAOCAOTONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOTON bAOCAOTON = db.BAOCAOTONs.Find(id);
            if (bAOCAOTON == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAOTON);
        }

        // POST: BAOCAOTONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BAOCAOTON bAOCAOTON = db.BAOCAOTONs.Find(id);
            db.BAOCAOTONs.Remove(bAOCAOTON);
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
