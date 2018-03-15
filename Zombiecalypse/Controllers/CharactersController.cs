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
using Zombiecalypse.ViewModels;

namespace Zombiecalypse.Controllers
{
    public class CharactersController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult AddToXP(int? id, int? add) {

            Character character = db.Characters.Find(id);
            int CharLevel = character.CharacterLevel;
            int CharXP = character.CharacterXP;
            Level DbLevel = db.Levels.Where(x=> x.LevelID == CharLevel).SingleOrDefault();
            int DbLevelLevel = DbLevel.LevelID;
            int DbLevelXP = DbLevel.LevelMaxXP;
            CharXP += (int)add;

            character.CharacterXP = CharXP;
            if (CharXP >= DbLevelXP) {
                CharLevel++;
                character.CharacterLevel = CharLevel;
            }
            ViewBag.Add = add;
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public Character GetCharacter(int? id) {
            Character character = db.Characters.Find(id);
            return character;
        }

        public ActionResult GetCharacterVM(int? id)
        {
            CharacterViewModel chvm = new CharacterViewModel();
            chvm.Character = GetCharacter(id);
            return View(chvm);
        }

        public ActionResult AddToEnergy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterID = new SelectList(db.Users, "UserID", "UserName", character.CharacterID);
            if (character.CurrentEnergy < character.MaxEnergy)
            {
                character.CurrentEnergy++;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        // GET: Characters
        public ActionResult Index()
        {
            var characters = db.Characters.Include(c => c.User);
            return View(characters.ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.CharacterID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharacterID,CharacterName,CharacterType,MaxEnergy,CurrentEnergy,UserID")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharacterID = new SelectList(db.Users, "UserID", "UserName", character.CharacterID);
            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterID = new SelectList(db.Users, "UserID", "UserName", character.CharacterID);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacterID,CharacterName,CharacterType,MaxEnergy,CurrentEnergy,UserID")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterID = new SelectList(db.Users, "UserID", "UserName", character.CharacterID);
            return View(character);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
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
