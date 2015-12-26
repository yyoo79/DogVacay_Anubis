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
            ViewBag.DogId = new SelectList(db.Dogs, "DogId", "FirstName");
            return View();
        }        

        // POST: Stay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StayId,DogId,StayDays,StartDate,EndDate")] Stay stay)
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

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Dog dog = db.Dogs.Find(id);
            //if (dog == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.HumanId1 = new SelectList(db.Humen, "HumanId", "FirstName", dog.HumanId1);
            //return View(dog);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stay stay = db.Stays.Find(id);
            if (stay == null)
            {
                return HttpNotFound();
            }
            ViewBag.DogId = new SelectList(db.Dogs, "DogId", "FirstName", stay.Dog.DogId);
            return View(stay);
        }

        // POST: Stay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StayId,DogId,StayDays,StartDate,EndDate")] Stay stay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.HumanId1 = new SelectList(db.Humen, "HumanId", "FirstName", dog.HumanId1);
            ViewBag.DogId = new SelectList(db.Dogs, "DogId", "FirstName", stay.Dog.DogId);
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
        
        //// GET: Stay/GetEvents
        //public ActionResult GetEvents(double start, double end)
        //{
        //    var fromDate = ConvertFromUnixTimestamp(start);
        //    var toDate = ConvertFromUnixTimestamp(end);

        //    //Get the events
        //    //You may get from the repository also
        //    var eventList = GetEvents();

        //    var rows = eventList.ToArray();
        //    return Json(rows, JsonRequestBehavior.AllowGet);
        //}

        // GET: Stay/GetEvents
        public ActionResult GetEvents()
        {
            //var fromDate = ConvertFromUnixTimestamp(start);
            //var toDate = ConvertFromUnixTimestamp(end);

            //Get the events
            //You may get from the repository also
            //var eventList = GetEvents2();
            var eventList = GetEventsFromDB();

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private List<CalEventModel> GetEventsFromDB()
        {
            // this is random object for picking random color for each Stay
            var Random1 = new Random();

            List<CalEventModel> eventList = new List<CalEventModel>();
            if (ModelState.IsValid)
            {                
                List<Stay> stayList = db.Stays.ToList();
                foreach (var stay in stayList)
                {
                    DateTime startDateDT = stay.StartDate.GetValueOrDefault(DateTime.Now);
                    DateTime endDateDT = stay.EndDate.GetValueOrDefault(DateTime.Now).AddDays(1);                    
                    CalEventModel newEvent = new CalEventModel
                    {
                        id = "1",
                        title = stay.Dog.FirstName, //"Event 1",
                        start = startDateDT.ToString("s"), //DateTime.Now.AddDays(1).ToString("s"),
                        end = endDateDT.ToString("s"), //DateTime.Now.AddDays(1).ToString("s"),
                        allDay = true
                    };

                    newEvent.color = colorArray[Random1.Next(0, colorArray.Length)];
                    eventList.Add(newEvent);
                }                
            }
            return eventList;
        }

        private List<CalEventModel> GetEvents2()
        {
            List<CalEventModel> eventList = new List<CalEventModel>();

            CalEventModel newEvent = new CalEventModel
            {
                id = "1",
                title = "Event 1",
                start = DateTime.Now.AddDays(1).ToString("s"),
                end = DateTime.Now.AddDays(1).ToString("s"),
                allDay = false
            };
            
            eventList.Add(newEvent);

            newEvent = new CalEventModel
            {
                id = "1",
                title = "Event 3",
                start = DateTime.Now.AddDays(2).ToString("s"),
                end = DateTime.Now.AddDays(3).ToString("s"),
                allDay = false
            };

            eventList.Add(newEvent);

            return eventList;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        private string[] colorArray = new string[] { 
            "#5d8aa8", "#e32636", "#9966cc", "#915c83", "#008000", "#4b5320", "#a52a2a", "#6e7f80", "#007fff", "#98777b",
            "#3d2b1f", "#318ce7", "#0d98ba", "#8a2be2", "#79443b", "#cc0000", "#873260", "#006a4e", "#cb4154", "#c32148",
            "#004225", "#a52a2a", "#480607", "#800020", "#cc5500", "#8a3324", "#bd33a4", "#702963", "#007aa5", "#e03c31",
            "#536872", "#4b3621", "#1e4d2b", "#78866b", "#ff0800", "#592720", "#eb4c42", "#007ba7", "#a0785a", "#d2691e"            
            };

        //private string[] getcolorArray()
        //{
        //    return colorArray;
        //    //return colorArray[new Random().Next(0, colorArray.Length)];
        //}

    }
}
