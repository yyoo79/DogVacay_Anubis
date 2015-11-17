using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DogVacay_Anubis_1509.Models;

namespace DogVacay_Anubis_1509.Controllers
{
    public class StayController : Controller
    {
        private DogVacayDataEntities db = new DogVacayDataEntities();

        // GET: Stay
        public ActionResult Index()
        {
            return View(db.Stays.ToList());
        }

        // GET: Stay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stay stay = db.Stays.Find(id);
            if (stay == null)
            {
                return HttpNotFound();
            }
            return View(stay);
        }

        // GET: Stay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StayId,StayDays,StartDate,EndDate")] Stay stay)
        {
            if (ModelState.IsValid)
            {
                db.Stays.Add(stay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stay);
        }

        // GET: Stay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stay stay = db.Stays.Find(id);
            if (stay == null)
            {
                return HttpNotFound();
            }
            return View(stay);
        }

        // POST: Stay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StayId,StayDays,StartDate,EndDate")] Stay stay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stay);
        }

        // GET: Stay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stay stay = db.Stays.Find(id);
            if (stay == null)
            {
                return HttpNotFound();
            }
            return View(stay);
        }

        // POST: Stay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stay stay = db.Stays.Find(id);
            db.Stays.Remove(stay);
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
