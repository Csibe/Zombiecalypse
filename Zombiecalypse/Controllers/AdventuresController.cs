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


        public ActionResult AdventureCounter(int? AdId, int ChId)
        {

            Adventure adventure = db.Adventures.Find(AdId);
            Character character = db.Characters.Find(ChId);

            ViewBag.BeforeCharacterFinishDate = character.FinishAdventure;


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

            db.SaveChanges();
            return View(adventure);
        }

        public ActionResult AttackZombie(int adventureId, int ChId)
        {
            ZombieAttackAdventurer zAA = db.ZombieAttackAdventurers.Find(adventureId);
            db.ZombieAttackAdventurers.Remove(zAA);
            db.SaveChanges();
            return RedirectToAction("AdventureZombieAttack", "Adventures", new { AdId = adventureId, ChId = ChId });
        }

        public ActionResult RemoveAdventure(int ChId)
        {

            var remove = db.ZombieAttackAdventurers.Where(x => x.CharacterID == ChId).ToList();
            remove.ForEach(s => db.ZombieAttackAdventurers.Remove(s));
            db.SaveChanges();

            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }


        public ActionResult AdventureZombieAttack(int ChId)
        {
            AdventureViewModel adventureViewModel = new AdventureViewModel();
            Character character = db.Characters.Find(ChId);
            Adventure adventure = db.Adventures.Find(1);
            adventureViewModel.AttackingZombies = db.ZombieAttackAdventurers.Where(x => x.CharacterID == ChId).ToList();
            adventureViewModel.CharacterID = ChId;
            adventureViewModel.Character = character;

            int counter1 = adventureViewModel.AttackingZombies.Where(x => x.State == 1).Count();
            int counter2 = adventureViewModel.AttackingZombies.Where(x => x.State == 2).Count();
            int counter3 = adventureViewModel.AttackingZombies.Where(x => x.State == 3).Count();

            if (counter3 == 0 && character.AdventureState <= 3)
            {
                character.AdventureState = 4;
                character.FinishAdventure = DateTime.Now.AddSeconds(adventure.AdventureWaitingTime);
                db.SaveChanges();
                return RedirectToAction("AdventureCounter", "Adventures", new { AdId = 1, ChId = ChId });
            }
            else if (counter3 != 0 && counter2 == 0 && counter1 == 0 && character.AdventureState <= 2)
            {
                character.AdventureState = 3;
                character.FinishAdventure = DateTime.Now.AddSeconds(adventure.AdventureWaitingTime);
                db.SaveChanges();
                return RedirectToAction("AdventureCounter", "Adventures", new { AdId = 1, ChId = ChId });
            }

            else if (counter2 != 0 && counter1 == 0 && character.AdventureState == 1)
            {
                character.AdventureState = 2;
                character.FinishAdventure = DateTime.Now.AddSeconds(adventure.AdventureWaitingTime);
                db.SaveChanges();
                return RedirectToAction("AdventureCounter", "Adventures", new { AdId = 1, ChId = ChId });
            }
            else if (counter1 != 0)
            {
                character.AdventureState = 1;
            }
            else
            {
                character.AdventureState = 66;
            }

            return View(adventureViewModel);
        }


        public ActionResult AddToInventory(int ChId, int ItemId, int addPieces)
        {

            Inventory inventory = db.Inventories.Where(s => s.ItemID == ItemId).Where(s => s.CharacterID == ChId).FirstOrDefault();
            if (inventory == null)
            {
                Inventory newinventory = new Inventory { ItemID = ItemId, ItemPieces = addPieces, CharacterID = ChId };
                db.Inventories.Add(newinventory);
            }
            else
            {
                inventory.ItemPieces += addPieces;
            }
            db.SaveChanges();
            return View();
        }



        public ActionResult AdventureDropCalculator(int? AdId, int ChId, string returnUrl)
        {

            AdventureDrop adventureDrop = new AdventureDrop();

            List<AdventureDrop> dropList = db.AdventureDrops.Where(a => a.AdventureID == AdId).ToList();
            List<double> randList = new List<double>();
            List<double> randList2 = new List<double>();
            List<double> drops = new List<double>();
            List<string> dropsString = new List<string>();
            List<int> pieces = new List<int>();

            Random rand = new Random();
            Random rand2 = new Random();
            foreach (AdventureDrop drop in dropList)
            {

                double myRand = rand.NextDouble();

                if (myRand > (1 - drop.ItemDroprate))
                {
                    drops.Add(drop.DropableItemID);

                    randList.Add(1 - myRand);
                    randList2.Add(myRand);
                    int addPieces = rand2.Next(1, drop.ItemMaxDrop);
                    pieces.Add(addPieces);
                    dropsString.Add("ItemID: " + drop.DropableItemID + ", ItemName: " + drop.Item.ItemName + ", ItemPieces: " + addPieces);
                    int dropID = drop.DropableItemID;
                    // Inventory inventory2 = new Inventory { CharacterID = ChId, ItemID = drop.DropableItemID, ItemPieces = addPieces };
                    var addItem = new AdventuresController().AddToInventory(ChId, dropID, addPieces);
                    // db.Inventories.Add(inventory2);
                    // db.SaveChanges();

                }
                else
                {
                    drops.Add(0);
                    randList.Add(1 - myRand);
                    randList2.Add(myRand);
                    pieces.Add(999);
                    dropsString.Add("semmi");
                }
            }



            ViewBag.RandList = randList;
            ViewBag.RandList2 = randList2;
            ViewBag.Drops = drops;
            ViewBag.Pieces = pieces;
            ViewBag.DropsString = dropsString;
            return RedirectToAction(returnUrl);
        }


        public ActionResult CheckAdventure(int? AdId, int ChId)
        {
            Adventure adventure = db.Adventures.Find(AdId);
            Character character = db.Characters.Find(ChId);


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


            return View(adventure);
        }


        public ActionResult StartAdventure(int? AdId, int ChId)
        {
            Adventure adventure = db.Adventures.Find(AdId);
            Character character = db.Characters.Find(ChId);
            Zombie zombie = db.Zombies.Find(1);
            List<ZombieAttackAdventurer> zombies = new List<ZombieAttackAdventurer> {
                new ZombieAttackAdventurer { ZombieID=1, CharacterID=ChId, State=1, ZombieLife=zombie.ZombieLife},
                new ZombieAttackAdventurer { ZombieID=1, CharacterID=ChId, State=1, ZombieLife=zombie.ZombieLife},
                new ZombieAttackAdventurer { ZombieID=1, CharacterID=ChId, State=2, ZombieLife=zombie.ZombieLife},
                new ZombieAttackAdventurer { ZombieID=1, CharacterID=ChId, State=3, ZombieLife=zombie.ZombieLife},
                new ZombieAttackAdventurer { ZombieID=1, CharacterID=ChId, State=3, ZombieLife=zombie.ZombieLife},
                new ZombieAttackAdventurer { ZombieID=1, CharacterID=ChId, State=3, ZombieLife=zombie.ZombieLife}
            };

            zombies.ForEach(x => db.ZombieAttackAdventurers.Add(x));

            ViewBag.BeforeCharacterFinishDate = character.FinishAdventure;

            character.FinishAdventure = DateTime.Now.AddSeconds(adventure.AdventureWaitingTime);
            character.AdventureState = 1;


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

            character.FinishAdventure = DateTime.MaxValue;
            character.IsOnAdventure = false;
            var addXP = new CharactersController().AddToXP(character.CharacterID, adventure.AdventureXPBonus, this.Request.FilePath);
            var addDrops = new AdventuresController().AdventureDropCalculator(AdId, ChId, this.Request.FilePath);
            db.SaveChanges();
            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
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
