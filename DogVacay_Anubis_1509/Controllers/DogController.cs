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
    public class DogController : Controller
    {
        private DogVacayDataEntities db = new DogVacayDataEntities();

        // GET: Dog
        public ActionResult Index()
        {
            var dogs = db.Dogs.Include(d => d.Human);
            return View(dogs.ToList());
        }

        // GET: Dog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // GET: Dog/Create
        public ActionResult Create()
        {
            ViewBag.HumanId1 = new SelectList(db.Humen, "HumanId", "FirstName");
            return View();
        }

        // POST: Dog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DogId,FirstName,LastName,Sex,Breed,Age,DOB,HumanId1")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Dogs.Add(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HumanId1 = new SelectList(db.Humen, "HumanId", "FirstName", dog.HumanId1);
            return View(dog);
        }

        // GET: Dog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            ViewBag.HumanId1 = new SelectList(db.Humen, "HumanId", "FirstName", dog.HumanId1);
            return View(dog);
        }

        // POST: Dog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DogId,FirstName,LastName,Sex,Breed,Age,DOB,HumanId1")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HumanId1 = new SelectList(db.Humen, "HumanId", "FirstName", dog.HumanId1);
            return View(dog);
        }

        // GET: Dog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // POST: Dog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dog dog = db.Dogs.Find(id);
            db.Dogs.Remove(dog);
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
