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

        private string CreateIdAuto()
        {
            int id_num = 1;
            if (db.VATTUs.Count() != 0)
            {
                var phieu_last = db.VATTUs.OrderByDescending(p => p.MaVatTu).FirstOrDefault();
                id_num = Int32.Parse((phieu_last.MaVatTu).Substring(2)) + 1;
            }
            string id = id_num.ToString();
            while (id.Length < 6)
                id = "0" + id;
            return "VT" + id;
        }


        // GET: VATTUs/Create
        public ActionResult Create()
        {
            ViewBag.loi = false;
            int countSoVatTu = db.VATTUs.ToList().Count;
            int soVatTuToiDa = db.THAMSOes.ToList().ElementAt(2).GiaTri;
            if (countSoVatTu >= soVatTuToiDa)
                ViewBag.loi = true;

            VATTU model = new VATTU();
            model.MaVatTu = CreateIdAuto();
            model.SoLuong = 0;
            model.DonGia = 0;
            return View(model);
        }

        // POST: VATTUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVatTu,TenVatTu,SoLuong,DonGia")] VATTU vATTU)
        {
            int countSoVatTu = db.VATTUs.ToList().Count;
            int soVatTuToiDa = db.THAMSOes.ToList().ElementAt(2).GiaTri;
            if (countSoVatTu == soVatTuToiDa)
            {
                return RedirectToAction("Create");
            }
            else if (ModelState.IsValid && countSoVatTu < soVatTuToiDa)
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


//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using BrotherGara.Models;

//namespace BrotherGara.Controllers
//{
//    public class VATTUsController : Controller
//    {
//        private BrothersGarageEntities db = new BrothersGarageEntities();

//        // GET: VATTUs
//        public ActionResult Index()
//        {
//            return View(db.VATTUs.ToList());
//        }

//        // GET: VATTUs/Details/5
//        public ActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            VATTU vATTU = db.VATTUs.Find(id);
//            if (vATTU == null)
//            {
//                return HttpNotFound();
//            }
//            return View(vATTU);
//        }

//        // GET: VATTUs/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: VATTUs/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "MaVatTu,TenVatTu,SoLuong,DonGia")] VATTU vATTU)
//        {
//            if (ModelState.IsValid)
//            {
//                db.VATTUs.Add(vATTU);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(vATTU);
//        }

//        // GET: VATTUs/Edit/5
//        public ActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            VATTU vATTU = db.VATTUs.Find(id);
//            if (vATTU == null)
//            {
//                return HttpNotFound();
//            }
//            return View(vATTU);
//        }

//        // POST: VATTUs/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "MaVatTu,TenVatTu,SoLuong,DonGia")] VATTU vATTU)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(vATTU).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(vATTU);
//        }

//        // GET: VATTUs/Delete/5
//        public ActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            VATTU vATTU = db.VATTUs.Find(id);
//            if (vATTU == null)
//            {
//                return HttpNotFound();
//            }
//            return View(vATTU);
//        }

//        // POST: VATTUs/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(string id)
//        {
//            VATTU vATTU = db.VATTUs.Find(id);
//            db.VATTUs.Remove(vATTU);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
