using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zombiecalypse.Models;

namespace Zombiecalypse.DAL
{
        public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
        {
            protected override void Seed(DataContext context)
            {

            
                    var users = new List<User>
                {

                new User{UserID=1, UserEmail="Email1", UserName="Username1", UserPassword="UserPassword1"},
                 new User{UserID=2, UserEmail="Emai2", UserName="Username2", UserPassword="UserPassword2"}
                };

                    users.ForEach(s => context.Users.Add(s));
                    context.SaveChanges();


                 var characters = new List<Character>
                {
                new Character{CharacterID=1, CharacterName="Charname1", CharacterType=1, CharacterXP=100, CharacterLevel=1, CurrentEnergy=10, IsOnAdventure=false, MaxEnergy=10, FinishAdventure=DateTime.MaxValue },
                new Character{CharacterID=2, CharacterName="Charname2", CharacterType=1, CharacterXP=100, CharacterLevel=1, CurrentEnergy=10, IsOnAdventure=false, MaxEnergy=10, FinishAdventure=DateTime.MaxValue }
                };
                    characters.ForEach(s => context.Characters.Add(s));
                    context.SaveChanges();

    
                var items = new List<Item> {
                    new Models.Item {ItemName="Csakegyitem", ItemType="item", ItemPicture="/Content/Pictures/Items/battery.png"}
                };

                items.ForEach(s => context.Items.Add(s));
                context.SaveChanges();

                    var buildings = new List<Building>
                {
                new Building{ItemName="House", BuildingLevel=1, ItemType="building", BuildingEnergyCost=2, BuildingMoneyCost=100, ItemPicture="/Content/Pictures/Buildings/house1.png"},
                new Building{ItemName="House", BuildingLevel=2, ItemType="building", BuildingEnergyCost=3, BuildingMoneyCost=200, ItemPicture="/Content/Pictures/Buildings/house2.png"},
                new Building{ItemName="House", BuildingLevel=3, ItemType="building", BuildingEnergyCost=4, BuildingMoneyCost=300, ItemPicture="/Content/Pictures/Buildings/house3.png"},
                new Building{ItemName="House", BuildingLevel=4, ItemType="building", BuildingEnergyCost=5, BuildingMoneyCost=400, ItemPicture="/Content/Pictures/Buildings/house4.png"},
                new Building{ItemName="House", BuildingLevel=5, ItemType="building"}
                };
                    buildings.ForEach(s => context.Buildings.Add(s));
                    context.SaveChanges();


                var buildingmaterials = new List<BuildingMaterial>
                {
                new BuildingMaterial{ItemName="blueprint", ItemType="buildingmaterial", ItemPicture="/Content/Pictures/Items/blueprint.PNG"},
                new BuildingMaterial {ItemName="board", ItemType="buildingmaterial"},
                new BuildingMaterial {ItemName="metal shed", ItemType="buildingmaterial"},
                new BuildingMaterial {ItemName="roof tile", ItemType="buildingmaterial"},
                new BuildingMaterial {ItemName="screw", ItemType="buildingmaterial"},
                };
                buildingmaterials.ForEach(s => context.BuildingMaterials.Add(s));
                    context.SaveChanges();



            var buildingbuildingmaterials = new List<BuildingBuildingMaterial> {
                   new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=7, MaterialPieces=3, ItemName="blueprint" },
                   new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=8, MaterialPieces=2, ItemName="board" },
                   new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=7, MaterialPieces=5, ItemName="blueprint" },
                   new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=8, MaterialPieces=5, ItemName="board" }
            };
            buildingbuildingmaterials.ForEach(s => context.BuildingBuildingMaterials.Add(s));
            context.SaveChanges();

            var levels = new List<Level> {
                   new Level { LevelID=1, LevelMaxXP=10},
                   new Level { LevelID=2, LevelMaxXP=100},
                   new Level { LevelID=3, LevelMaxXP=1000}
            };

            levels.ForEach(s => context.Levels.Add(s));
            context.SaveChanges();


            var adventures = new List<Adventure> {
                new Adventure { AdventureName="Short Adventure", AdventureTime=10},
                new Adventure { AdventureName="Middle Adventure", AdventureTime=15}
            };
            adventures.ForEach(s => context.Adventures.Add(s));
            context.SaveChanges();


            var buildings2 = new List<Building>
                {
                new Building { ItemName = "Garage", BuildingLevel = 1, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_1.png" },
                new Building { ItemName = "Garage", BuildingLevel = 2, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_2.png" },
                };
            buildings2.ForEach(s => context.Buildings.Add(s));
            context.SaveChanges();

            var inventories = new List<Inventory> {
                   new Inventory {InventoryID=1, CharacterID=1, ItemID=2, ItemPieces=1},
                   new Inventory {InventoryID=1, CharacterID=1, ItemID=16, ItemPieces=1},
                   new Inventory {InventoryID=1, CharacterID=1, ItemID=7, ItemPieces=5},
                   new Inventory {InventoryID=1, CharacterID=1, ItemID=8, ItemPieces=5},
                   new Inventory {InventoryID=1, CharacterID=1, ItemID=1, ItemPieces=5},
                   new Inventory {InventoryID=2, CharacterID=2, ItemID=6, ItemPieces=3},
                   new Inventory {InventoryID=2, CharacterID=2, ItemID=9, ItemPieces=8},
                   new Inventory {InventoryID=1, CharacterID=1, ItemID=11, ItemPieces=8},
            };
            inventories.ForEach(s => context.Inventories.Add(s));
            context.SaveChanges();
            

        }
    }
  }
