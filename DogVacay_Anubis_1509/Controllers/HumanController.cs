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
    public class HumanController : Controller
    {
        private DogVacayDataEntities db = new DogVacayDataEntities();

        // GET: Human
        public ActionResult Index()
        {
            return View(db.Humen.ToList());
        }

        // GET: Human/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Human human = db.Humen.Find(id);
            if (human == null)
            {
                return HttpNotFound();
            }
            return View(human);
        }

        // GET: Human/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Human/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HumanId,FirstName")] Human human)
        {
            if (ModelState.IsValid)
            {
                db.Humen.Add(human);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(human);
        }

        // GET: Human/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Human human = db.Humen.Find(id);
            if (human == null)
            {
                return HttpNotFound();
            }
            return View(human);
        }

        // POST: Human/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HumanId,FirstName")] Human human)
        {
            if (ModelState.IsValid)
            {
                db.Entry(human).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(human);
        }

        // GET: Human/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Human human = db.Humen.Find(id);
            if (human == null)
            {
                return HttpNotFound();
            }
            return View(human);
        }

        // POST: Human/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Human human = db.Humen.Find(id);
            db.Humen.Remove(human);
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
