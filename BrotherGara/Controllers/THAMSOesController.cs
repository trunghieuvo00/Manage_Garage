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
    public class THAMSOesController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: THAMSOes
        public ActionResult Index()
        {
            return View(db.THAMSOes.ToList());
        }

        // GET: THAMSOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMSO tHAMSO = db.THAMSOes.Find(id);
            if (tHAMSO == null)
            {
                return HttpNotFound();
            }
            return View(tHAMSO);
        }

        // GET: THAMSOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THAMSOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenThamSo,GiaTri")] THAMSO tHAMSO)
        {
            if (ModelState.IsValid)
            {
                db.THAMSOes.Add(tHAMSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHAMSO);
        }

        // GET: THAMSOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMSO tHAMSO = db.THAMSOes.Find(id);
            if (tHAMSO == null)
            {
                return HttpNotFound();
            }
            return View(tHAMSO);
        }

        // POST: THAMSOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenThamSo,GiaTri")] THAMSO tHAMSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHAMSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHAMSO);
        }

        // GET: THAMSOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMSO tHAMSO = db.THAMSOes.Find(id);
            if (tHAMSO == null)
            {
                return HttpNotFound();
            }
            return View(tHAMSO);
        }

        // POST: THAMSOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THAMSO tHAMSO = db.THAMSOes.Find(id);
            db.THAMSOes.Remove(tHAMSO);
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
