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
    public class NOIDUNGDOANHSOesController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: NOIDUNGDOANHSOes
        public ActionResult Index(string id)
        {
            var nOIDUNGDOANHSOes = db.NOIDUNGDOANHSOes.Include(n => n.HIEUXE).Include(n => n.PHIEUDOANHSO);
            var result = nOIDUNGDOANHSOes.ToList().Where(x => x.MaPDS == id);
            return View(result);
        }

        // GET: NOIDUNGDOANHSOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOIDUNGDOANHSO nOIDUNGDOANHSO = db.NOIDUNGDOANHSOes.Find(id);
            if (nOIDUNGDOANHSO == null)
            {
                return HttpNotFound();
            }
            return View(nOIDUNGDOANHSO);
        }
        private string CreateIdAuto()
        {
            int id_num = 1;
            if (db.NOIDUNGDOANHSOes.Count() != 0)
            {
                var phieu_last = db.NOIDUNGDOANHSOes.OrderByDescending(p => p.MaNDDS).FirstOrDefault();
                id_num = Int32.Parse((phieu_last.MaNDDS).Substring(4)) + 1;
            }
            string id = id_num.ToString();
            while (id.Length < 4)
                id = "0" + id;
            return "NDDS" + id;
        }
        // GET: NOIDUNGDOANHSOes/Create
        public ActionResult Create()
        {
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe");
            ViewBag.MaPDS = new SelectList(db.PHIEUDOANHSOes, "MaPDS", "MaTN");
            ViewBag.MaPTT = new SelectList(db.PHIEUTHUTIENs, "MaPTT", "MaPSC");

            NOIDUNGDOANHSO model = new NOIDUNGDOANHSO();
            model.MaNDDS = CreateIdAuto();
            return View(model);
        }

        // POST: NOIDUNGDOANHSOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNDDS,MaPDS,MaPTT,MaHieuXe,SoLuotSua,ThanhTien,TiLe")] NOIDUNGDOANHSO nOIDUNGDOANHSO)
        {

            int idMax = int.Parse(db.NOIDUNGDOANHSOes.OrderByDescending(p => p.MaNDDS).FirstOrDefault()?.MaNDDS.Substring(4) ?? "0");
            nOIDUNGDOANHSO.MaNDDS = "NDDS" + (idMax + 1).ToString("D4");

            var data = from tiepnhan in db.TIEPNHANs
                       join phieusuachua in db.PHIEUSUACHUAs on tiepnhan.MaTiepNhan equals phieusuachua.MaTiepNhan
                       where tiepnhan.MaHieuXe == nOIDUNGDOANHSO.MaHieuXe
                       select new { tongTien = phieusuachua.TongTien };

            var tongdoanhthu = db.PHIEUDOANHSOes.Find(nOIDUNGDOANHSO.MaPDS).TongDoanhThu;

            if (data.Count() > 0)
            {
                nOIDUNGDOANHSO.SoLuotSua = data.Count();
                nOIDUNGDOANHSO.ThanhTien = data.Sum(x => x.tongTien);
                nOIDUNGDOANHSO.TiLe = (double)(data.Sum(x => x.tongTien) / tongdoanhthu);
            }

            if (ModelState.IsValid)
            {
                db.NOIDUNGDOANHSOes.Add(nOIDUNGDOANHSO);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = nOIDUNGDOANHSO.MaPDS });
            }

            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", nOIDUNGDOANHSO.MaHieuXe);
            ViewBag.MaPDS = new SelectList(db.PHIEUDOANHSOes, "MaPDS", "MaTN", nOIDUNGDOANHSO.MaPDS);
            ViewBag.MaPTT = new SelectList(db.PHIEUTHUTIENs, "MaPTT", "MaPSC", nOIDUNGDOANHSO.MaPDS);
            return View(nOIDUNGDOANHSO);
        }

        // GET: NOIDUNGDOANHSOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOIDUNGDOANHSO nOIDUNGDOANHSO = db.NOIDUNGDOANHSOes.Find(id);
            if (nOIDUNGDOANHSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", nOIDUNGDOANHSO.MaHieuXe);
            ViewBag.MaPDS = new SelectList(db.PHIEUDOANHSOes, "MaPDS", "MaTN", nOIDUNGDOANHSO.MaPDS);
            ViewBag.MaPTT = new SelectList(db.PHIEUTHUTIENs, "MaPTT", "MaPSC", nOIDUNGDOANHSO.MaPDS);
            return View(nOIDUNGDOANHSO);
        }

        // POST: NOIDUNGDOANHSOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNDDS,MaPDS,MaPTT,MaHieuXe,SoLuotSua,ThanhTien,TiLe")] NOIDUNGDOANHSO nOIDUNGDOANHSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOIDUNGDOANHSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHieuXe = new SelectList(db.HIEUXEs, "MaHieuXe", "TenHieuXe", nOIDUNGDOANHSO.MaHieuXe);
            ViewBag.MaPDS = new SelectList(db.PHIEUDOANHSOes, "MaPDS", "MaTN", nOIDUNGDOANHSO.MaPDS);
            ViewBag.MaPTT = new SelectList(db.PHIEUTHUTIENs, "MaPTT", "MaPSC", nOIDUNGDOANHSO.MaPDS);
            return View(nOIDUNGDOANHSO);
        }

        // GET: NOIDUNGDOANHSOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOIDUNGDOANHSO nOIDUNGDOANHSO = db.NOIDUNGDOANHSOes.Find(id);
            if (nOIDUNGDOANHSO == null)
            {
                return HttpNotFound();
            }
            return View(nOIDUNGDOANHSO);
        }

        // POST: NOIDUNGDOANHSOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NOIDUNGDOANHSO nOIDUNGDOANHSO = db.NOIDUNGDOANHSOes.Find(id);
            var MaPDS = nOIDUNGDOANHSO.MaPDS;
            db.NOIDUNGDOANHSOes.Remove(nOIDUNGDOANHSO);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = MaPDS });
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