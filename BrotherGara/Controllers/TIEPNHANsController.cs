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
    public class TIEPNHANsController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: TIEPNHANs
        public ActionResult Index()
        {
            var tIEPNHANs = db.TIEPNHANs.Include(t => t.HIEUXE);
            return View(tIEPNHANs.ToList());
        }

        // GET: TIEPNHANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIEPNHAN tIEPNHAN = db.TIEPNHANs.Find(id);
            if (tIEPNHAN == null)
            {
                return HttpNotFound();
            }
            return View(tIEPNHAN);
        }

        private string CreateIdAuto()
        {
            int id_num = 1;
            if (db.TIEPNHANs.Count() != 0)
            {
                var phieu_last = db.TIEPNHANs.OrderByDescending(p => p.MaTiepNhan).FirstOrDefault();
                id_num = Int32.Parse((phieu_last.MaTiepNhan).Substring(2)) + 1;
            }
            string id = id_num.ToString();
            while (id.Length < 6)
                id = "0" + id;
            return "TN" + id;
        }

        // GET: TIEPNHANs/Create
        public ActionResult Create()
        {
            ViewBag.loi = false;
            int countTIEPNHANs = db.TIEPNHANs.ToList().Count();
            int tiepNhanToiDa = db.THAMSOes.ToList().ElementAt(3).GiaTri;
            if (countTIEPNHANs >= tiepNhanToiDa)
                ViewBag.loi = true;

            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe");

            TIEPNHAN model = new TIEPNHAN();
            model.MaTiepNhan = CreateIdAuto();
            model.NgayTiepNhan = DateTime.Now;

            return View(model);
        }

        // POST: TIEPNHANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTiepNhan,BienSo,TenChuXe,MaHieuXe,DiaChi,DienThoai,NgayTiepNhan,Email")] TIEPNHAN tIEPNHAN)
        {
            if (ModelState.IsValid)
            {
                tIEPNHAN.TienNo = 0;
                db.TIEPNHANs.Add(tIEPNHAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", tIEPNHAN.MaHieuXe);
            return View(tIEPNHAN);
        }

        // GET: TIEPNHANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIEPNHAN tIEPNHAN = db.TIEPNHANs.Find(id);
            if (tIEPNHAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", tIEPNHAN.MaHieuXe);
            return View(tIEPNHAN);
        }

        // POST: TIEPNHANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTiepNhan,BienSo,TenChuXe,MaHieuXe,DiaChi,DienThoai,NgayTiepNhan,TienNo,Email")] TIEPNHAN tIEPNHAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIEPNHAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", tIEPNHAN.MaHieuXe);
            return View(tIEPNHAN);
        }

        // GET: TIEPNHANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIEPNHAN tIEPNHAN = db.TIEPNHANs.Find(id);
            if (tIEPNHAN == null)
            {
                return HttpNotFound();
            }
            return View(tIEPNHAN);
        }

        // POST: TIEPNHANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TIEPNHAN tIEPNHAN = db.TIEPNHANs.Find(id);
            db.TIEPNHANs.Remove(tIEPNHAN);
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
