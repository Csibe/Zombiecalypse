using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{
    public class AdventuresController : Controller
    {
        private DataContext db = new DataContext();


        public ActionResult StartAdventure(int? AdId, int ChId) {
            Adventure adventure = db.Adventures.Find(AdId);
            Character character = db.Characters.Find(ChId);
            ViewBag.BeforeCharacterFinishDate = character.FinishAdventure;

            character.FinishAdventure = DateTime.Now.AddSeconds(adventure.AdventureTime);
            var FullDate = character.FinishAdventure;
            int CharID = ChId;
            int? AdvID = AdId;
            var FinishAdventureYear = character.FinishAdventure.Year;
            var FinishAdventureMonth = character.FinishAdventure.Month;
            var FinishAdventureDay = character.FinishAdventure.Day;
            var FinishAdventureHour = character.FinishAdventure.Hour;
            var FinishAdventureMinute = character.FinishAdventure.Minute;
            var FinishAdventureSecond = character.FinishAdventure.Second;


            ViewBag.CharID = CharID;
            ViewBag.AdvID = AdvID;

            ViewBag.FullDate = FullDate;

            ViewBag.FinishAdventureYear = FinishAdventureYear;
            ViewBag.FinishAdventureMonth = FinishAdventureMonth;
            ViewBag.FinishAdventureDay = FinishAdventureDay;
            ViewBag.FinishAdventureHour = FinishAdventureHour;
            ViewBag.FinishAdventureMinute = FinishAdventureMinute;
            ViewBag.FinishAdventureSecond = FinishAdventureSecond;



            character.IsOnAdventure = true;
            db.SaveChanges();
            return View(adventure);
        }

        public ActionResult StopAdventure(int? AdId, int ChId)
        {
            Adventure adventure = db.Adventures.Find(AdId);
            Character character = db.Characters.Find(ChId);


            character.IsOnAdventure = false;
            db.SaveChanges();
            return View(adventure);
        }

        // GET: Adventures
        public ActionResult Index()
        {
            return View(db.Adventures.ToList());
        }

        // GET: Adventures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adventure adventure = db.Adventures.Find(id);
            if (adventure == null)
            {
                return HttpNotFound();
            }
            return View(adventure);
        }

        // GET: Adventures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adventures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdventureID,AdventureTime")] Adventure adventure)
        {
            if (ModelState.IsValid)
            {
                db.Adventures.Add(adventure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adventure);
        }

        // GET: Adventures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adventure adventure = db.Adventures.Find(id);
            if (adventure == null)
            {
                return HttpNotFound();
            }
            return View(adventure);
        }

        // POST: Adventures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdventureID,AdventureTime")] Adventure adventure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adventure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adventure);
        }

        // GET: Adventures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adventure adventure = db.Adventures.Find(id);
            if (adventure == null)
            {
                return HttpNotFound();
            }
            return View(adventure);
        }

        // POST: Adventures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adventure adventure = db.Adventures.Find(id);
            db.Adventures.Remove(adventure);
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
