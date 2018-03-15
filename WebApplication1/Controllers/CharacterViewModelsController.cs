using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CharacterViewModelsController : Controller
    {
        private DataContext db = new DataContext();



        public ActionResult CharacterDetails(int? id)
        {

            Character character = db.Characters.Find(id);

            CharacterViewModel viewmodel = new CharacterViewModel();
            viewmodel.Character = character;


            var variable = from i in db.Buildings.OfType<Building>() select i;
            //IQueryable = from i in ctx.ProductItems.Include("Product") select i;
            //var variable = from s in ctx.Products.OfType() select s;


            viewmodel.CharacterName = character.CharacterName;
            viewmodel.CharacterItems = character.Inventory;
            viewmodel.CharacterType = character.CharacterType;
            return View(viewmodel);
        }


        // GET: CharacterViewModels
        public ActionResult Index()
        {
            return View(db.CharacterViewModels.ToList());
        }

        // GET: CharacterViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterViewModel characterViewModel = db.CharacterViewModels.Find(id);
            if (characterViewModel == null)
            {
                return HttpNotFound();
            }
            return View(characterViewModel);
        }

        // GET: CharacterViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharacterViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharacterViewModelID,CharacterName")] CharacterViewModel characterViewModel)
        {
            if (ModelState.IsValid)
            {
                db.CharacterViewModels.Add(characterViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(characterViewModel);
        }

        // GET: CharacterViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterViewModel characterViewModel = db.CharacterViewModels.Find(id);
            if (characterViewModel == null)
            {
                return HttpNotFound();
            }
            return View(characterViewModel);
        }

        // POST: CharacterViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacterViewModelID,CharacterName")] CharacterViewModel characterViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(characterViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(characterViewModel);
        }

        // GET: CharacterViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterViewModel characterViewModel = db.CharacterViewModels.Find(id);
            if (characterViewModel == null)
            {
                return HttpNotFound();
            }
            return View(characterViewModel);
        }

        // POST: CharacterViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharacterViewModel characterViewModel = db.CharacterViewModels.Find(id);
            db.CharacterViewModels.Remove(characterViewModel);
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
