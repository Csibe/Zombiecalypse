using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zombiecalypse.Models;
using Zombiecalypse.DAL;

namespace Zombiecalypse.Controllers
{
    public class DogsController : Controller
    {

        private DataContext db = new DataContext();


        // GET: Dogs
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SendDogToExplore()
        {

            SendDogToExplore model = new SendDogToExplore();
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            model.Dog = db.OwnedDogs.Where(x => x.CharacterID == character.CharacterID).First();

            if (model.Dog.IsOnExplore == true)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }
            else
            {

                model.Dog.IsOnExplore = true;
                model.Dog.EndOfExplore = DateTime.Now.AddMinutes(3);

                db.SaveChanges();
            }
            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }


        public ActionResult StopDogToExplore()
        {

            SendDogToExplore model = new SendDogToExplore();
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            model.Dog = db.OwnedDogs.Where(x => x.CharacterID == character.CharacterID).First();

            if (model.Dog.IsOnExplore == true)
            {
                var result = new DogsController().CollectReward(User.Identity.Name);

            }

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }




        public ActionResult CollectReward(string UserName)
        {

            int adventureNumber = db.Adventures.Count();
            Random rand = new Random();
           int randomAdvNum = rand.Next(0, adventureNumber);

            DogExploreDrop model = new DogExploreDrop();
            List<AdventureDrop> dropList = db.AdventureDrops.Where(a => a.AdventureID == randomAdvNum).ToList();
            model.ItemList = db.Items.ToList();
            model.Rewards = new List<Inventory>();

            Character character = db.Characters.Where(y => y.ApplicationUserID == UserName).FirstOrDefault();

            OwnedDog dog = db.OwnedDogs.Where(x => x.CharacterID == db.Characters.Where(y => y.CharacterID == character.CharacterID).FirstOrDefault().CharacterID).FirstOrDefault();

            if (dog.IsOnExplore == true)
            {

                foreach (var drop in dropList)
                {
                    double myRand = rand.NextDouble();

                    if (myRand > (1 - drop.ItemDroprate))
                    {
                        int addPieces = rand.Next(1, drop.ItemMaxDrop);
                        Inventory inventory = new Inventory { CharacterID = character.CharacterID, ItemID = drop.DropableItemID, ItemPieces = addPieces };
                        var addItem = new AdventuresController().AddToInventory(character.CharacterID, drop.DropableItemID, addPieces);

                        Inventory item = new Inventory { ItemID = drop.DropableItemID, ItemPieces = addPieces };

                        model.Rewards.Add(item);

                        db.SaveChanges();

                    }
                }

                dog.IsOnExplore = false;
                dog.EndOfExplore = DateTime.MaxValue;

                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            return View(model);
        }

    }
}