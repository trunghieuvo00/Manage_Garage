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
    public class PHIEUNHAPKHOesController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: PHIEUNHAPKHOes
        public ActionResult Index()
        {
            return View(db.PHIEUNHAPKHOes.ToList());
        }

        // GET: PHIEUNHAPKHOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pHIEUNHAPKHO = db.PHIEUNHAPKHOes.Find(id);
            if (pHIEUNHAPKHO == null)
            {
                return HttpNotFound();
            }

            //return Redirect($"/NOIDUNGNHAPKHOes/Index?mapnk={pHIEUNHAPKHO.MaPNK}");
            return RedirectToAction("Index", "NOIDUNGNHAPKHOes", new { @id = pHIEUNHAPKHO.MaPNK });
        }

        private string CreateIdAuto()
        {
            int id_num = 1;
            if (db.PHIEUNHAPKHOes.Count() != 0)
            {
                var phieu_last = db.PHIEUNHAPKHOes.OrderByDescending(p => p.MaPNK).FirstOrDefault();
                id_num = Int32.Parse((phieu_last.MaPNK).Substring(3)) + 1;
            }
            string id = id_num.ToString();
            while (id.Length < 5)
                id = "0" + id;
            return "PNK" + id;
        }

        // GET: PHIEUNHAPKHOes/Create
        public ActionResult Create()
        {
            PHIEUNHAPKHO model = new PHIEUNHAPKHO();
            model.MaPNK = CreateIdAuto();
            return View(model);
        }

        // POST: PHIEUNHAPKHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPNK,NgayNhapKho")] PHIEUNHAPKHO pHIEUNHAPKHO)
        {
            if (ModelState.IsValid)
            {
                pHIEUNHAPKHO.TongChi = 0;
                db.PHIEUNHAPKHOes.Add(pHIEUNHAPKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHIEUNHAPKHO);
        }

        // GET: PHIEUNHAPKHOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAPKHO pHIEUNHAPKHO = db.PHIEUNHAPKHOes.Find(id);
            if (pHIEUNHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAPKHO);
        }

        // POST: PHIEUNHAPKHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPNK,NgayNhapKho,TongChi")] PHIEUNHAPKHO pHIEUNHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUNHAPKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHIEUNHAPKHO);
        }

        // GET: PHIEUNHAPKHOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAPKHO pHIEUNHAPKHO = db.PHIEUNHAPKHOes.Find(id);
            if (pHIEUNHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAPKHO);
        }

        // POST: PHIEUNHAPKHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUNHAPKHO pHIEUNHAPKHO = db.PHIEUNHAPKHOes.Find(id);
            db.PHIEUNHAPKHOes.Remove(pHIEUNHAPKHO);
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
