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
    public class TIENCONGsController : Controller
    {
        private BrothersGarageEntities db = new BrothersGarageEntities();

        // GET: TIENCONGs
        public ActionResult Index()
        {
            return View(db.TIENCONGs.ToList());
        }

        // GET: TIENCONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIENCONG tIENCONG = db.TIENCONGs.Find(id);
            if (tIENCONG == null)
            {
                return HttpNotFound();
            }
            return View(tIENCONG);
        }

        // GET: TIENCONGs/Create
        public ActionResult Create()
        {
            ViewBag.loi = false;
            int countTIENCONGs = db.TIENCONGs.ToList().Count();
            int soTienCongToiDa = db.THAMSOes.ToList().ElementAt(1).GiaTri;
            if (countTIENCONGs >= soTienCongToiDa)
                ViewBag.loi = true;

            return View();
        }

        // POST: TIENCONGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTienCong,TenTienCong,TienCong1")] TIENCONG tIENCONG)
        {
            int countTIENCONGs = db.TIENCONGs.ToList().Count();
            int soTienCongToiDa = db.THAMSOes.ToList().ElementAt(1).GiaTri;
            if (countTIENCONGs == soTienCongToiDa)
            {
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid && countTIENCONGs < soTienCongToiDa)
            {
                db.TIENCONGs.Add(tIENCONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIENCONG);
        }

        // GET: TIENCONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIENCONG tIENCONG = db.TIENCONGs.Find(id);
            if (tIENCONG == null)
            {
                return HttpNotFound();
            }
            return View(tIENCONG);
        }

        // POST: TIENCONGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTienCong,TenTienCong,TienCong1")] TIENCONG tIENCONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIENCONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIENCONG);
        }

        // GET: TIENCONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIENCONG tIENCONG = db.TIENCONGs.Find(id);
            if (tIENCONG == null)
            {
                return HttpNotFound();
            }
            return View(tIENCONG);
        }

        // POST: TIENCONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TIENCONG tIENCONG = db.TIENCONGs.Find(id);
            db.TIENCONGs.Remove(tIENCONG);
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
//    public class TIENCONGsController : Controller
//    {
//        private BrothersGarageEntities db = new BrothersGarageEntities();

//        // GET: TIENCONGs
//        public ActionResult Index()
//        {
//            return View(db.TIENCONGs.ToList());
//        }

//        // GET: TIENCONGs/Details/5
//        public ActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            TIENCONG tIENCONG = db.TIENCONGs.Find(id);
//            if (tIENCONG == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tIENCONG);
//        }

//        // GET: TIENCONGs/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: TIENCONGs/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "MaTienCong,TenTienCong,TienCong1")] TIENCONG tIENCONG)
//        {
//            if (ModelState.IsValid)
//            {
//                db.TIENCONGs.Add(tIENCONG);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(tIENCONG);
//        }

//        // GET: TIENCONGs/Edit/5
//        public ActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            TIENCONG tIENCONG = db.TIENCONGs.Find(id);
//            if (tIENCONG == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tIENCONG);
//        }

//        // POST: TIENCONGs/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "MaTienCong,TenTienCong,TienCong1")] TIENCONG tIENCONG)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(tIENCONG).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(tIENCONG);
//        }

//        // GET: TIENCONGs/Delete/5
//        public ActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            TIENCONG tIENCONG = db.TIENCONGs.Find(id);
//            if (tIENCONG == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tIENCONG);
//        }

//        // POST: TIENCONGs/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(string id)
//        {
//            TIENCONG tIENCONG = db.TIENCONGs.Find(id);
//            db.TIENCONGs.Remove(tIENCONG);
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
