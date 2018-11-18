using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{
    public class MissionsController : Controller
    {


        private DataContext db = new DataContext();

        public ActionResult GenerateMission()
        {

            Mission model = new Models.Mission();

            List<BuildingMaterial> buildingMaterials = db.BuildingMaterials.ToList();

            List<Material> materials = db.Materials.ToList();

            Random rand = new Random();

            int rewardItem = rand.Next(0, db.BuildingMaterials.Count());

            int taskItem = rand.Next(0, db.Materials.Count());
           
            

            Mission mission = new Mission { CharacterID = User.Identity.Name, MissionTaskID = db.Materials.ToArray()[taskItem].ItemID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1};
            db.Missions.Add(mission);
            db.SaveChanges();


            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }
    }
}