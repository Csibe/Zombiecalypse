using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zombiecalypse.Models;

namespace Zombiecalypse.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {


        DataContext db = new DataContext();
        protected override void Seed(DataContext context)
        {

            var items = new List<Item> {
                    new Models.Item {ItemName="Csakegyitem", ItemType="item", ItemPicture="/Content/Pictures/Items/battery.png"}
                };

            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var buildings = new List<Building>
                {
                new Building{ItemName="House", BuildingLevel=1, ItemType="building", BuildingEnergyCost=0, BuildingMoneyCost=0, ItemPicture="/Content/Pictures/Buildings/House_1.png"},
                new Building{ItemName="House", BuildingLevel=2, ItemType="building", BuildingEnergyCost=3, BuildingMoneyCost=200, ItemPicture="/Content/Pictures/Buildings/House_2.png"},
                new Building{ItemName="House", BuildingLevel=3, ItemType="building", BuildingEnergyCost=4, BuildingMoneyCost=300, ItemPicture="/Content/Pictures/Buildings/House_3.png"},
                new Building{ItemName="House", BuildingLevel=4, ItemType="building", BuildingEnergyCost=5, BuildingMoneyCost=400, ItemPicture="/Content/Pictures/Buildings/House_4.png"},
                new Building{ItemName="House", BuildingLevel=5, ItemType="building", BuildingEnergyCost=5, BuildingMoneyCost=400, ItemPicture="/Content/Pictures/Buildings/House_5.png"}
                };
            buildings.ForEach(s => context.Items.Add(s));
            context.SaveChanges();


            var buildingmaterials = new List<BuildingMaterial>
                {
                new BuildingMaterial{ItemName="blueprint", ItemType="buildingmaterial", ItemPicture="/Content/Pictures/Items/Blueprint.PNG"},
                new BuildingMaterial {ItemName="board", ItemType="buildingmaterial", ItemPicture="/Content/Pictures/Items/Board.PNG"},
                new BuildingMaterial {ItemName="metal shed", ItemType="buildingmaterial", ItemPicture="/Content/Pictures/Items/MetalShed.PNG"},
                new BuildingMaterial {ItemName="roof tile", ItemType="buildingmaterial", ItemPicture="/Content/Pictures/Items/RoofTile.PNG"},
                new BuildingMaterial {ItemName="screw", ItemType="buildingmaterial", ItemPicture="/Content/Pictures/Items/Screw.PNG"},
                };
            buildingmaterials.ForEach(s => context.Items.Add(s));
            context.SaveChanges();



            var buildingbuildingmaterials = new List<BuildingBuildingMaterial> {
                   new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=7, MaterialPieces=3, ItemType="buildingbuildingmaterial" },
                   new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=8, MaterialPieces=2, ItemType="buildingbuildingmaterial"},
                   new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=7, MaterialPieces=5, ItemType="buildingbuildingmaterial" },
                   new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=8, MaterialPieces=5, ItemType="buildingbuildingmaterial" }
            };
            buildingbuildingmaterials.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var levels = new List<Level> {
            new Level {LevelMaxXP=25, LevelMaxEnergy=14},
            new Level {LevelMaxXP=40, LevelMaxEnergy=15},
            new Level {LevelMaxXP=80,  LevelMaxEnergy=15},
            new Level {LevelMaxXP=160,  LevelMaxEnergy=16},
            new Level { LevelMaxXP = 500, LevelMaxEnergy = 16 },
            new Level { LevelMaxXP = 1000, LevelMaxEnergy = 17 },
            new Level { LevelMaxXP = 1500, LevelMaxEnergy = 17 },
            new Level { LevelMaxXP = 2100, LevelMaxEnergy = 18 },
            new Level { LevelMaxXP = 2800, LevelMaxEnergy = 18 },
            new Level { LevelMaxXP = 3500, LevelMaxEnergy = 19 },
            new Level { LevelMaxXP = 4400, LevelMaxEnergy = 19 },
            new Level { LevelMaxXP = 5300, LevelMaxEnergy = 19 },
            new Level { LevelMaxXP = 4400, LevelMaxEnergy = 19 },
            new Level { LevelMaxXP = 5300, LevelMaxEnergy =19  },
            new Level { LevelMaxXP = 6400, LevelMaxEnergy = 19 },
            new Level { LevelMaxXP = 7400, LevelMaxEnergy = 19 },
            new Level { LevelMaxXP = 8400, LevelMaxEnergy = 19 },
            new Level { LevelMaxXP = 9500, LevelMaxEnergy = 20 },
            new Level { LevelMaxXP = 10700, LevelMaxEnergy = 20 },
            new Level { LevelMaxXP = 12200, LevelMaxEnergy =  20},
            new Level { LevelMaxXP = 14000, LevelMaxEnergy =  21},
            new Level { LevelMaxXP = 16500, LevelMaxEnergy =  21},
            new Level { LevelMaxXP = 20000, LevelMaxEnergy =  21},
            new Level { LevelMaxXP = 24000, LevelMaxEnergy =  21},
            new Level { LevelMaxXP = 28100, LevelMaxEnergy =  21},
            };

            levels.ForEach(s => context.Levels.Add(s));
            context.SaveChanges();


            var adventures = new List<Adventure> {
                new Adventure { AdventureName="Short Adventure", AdventureTime=10, AdventureXPBonus=6},
                new Adventure { AdventureName="Middle Adventure", AdventureTime=15, AdventureXPBonus=10}
            };
            adventures.ForEach(s => context.Adventures.Add(s));
            context.SaveChanges();


            var buildings2 = new List<Building>
                {
                new Building { ItemName = "Garage", BuildingLevel = 0, ItemDurability=0, ItemType = "building", BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/Garage_0.png" },
                new Building { ItemName = "Garage", BuildingLevel = 1, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_1.png" },
                new Building { ItemName = "Garage", BuildingLevel = 2, ItemDurability=3, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_2.png" },
                new Building { ItemName = "Garage", BuildingLevel = 3, ItemDurability=4, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_3.png" },
                new Building { ItemName = "Garage", BuildingLevel = 4, ItemDurability=5, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_4.png" },
                new Building { ItemName = "Garage", BuildingLevel = 5, ItemDurability=6, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_5.png" },

                new Building { ItemName = "GardenShed", BuildingLevel = 0, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/GardenShed_0.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 1, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_1.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 2, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_2.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 3, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_3.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 4, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_4.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 5, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_5.png" },

                new Building { ItemName = "ToolShed", BuildingLevel = 0, ItemType = "building", BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/ToolShed_0.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 1, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_1.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 2, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_2.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 3, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_3.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 4, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_4.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 5, ItemType = "building", BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_5.png" },
            };
            buildings2.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var zombies = new List<Zombie> {
                new Zombie { ZombieName="Salesman", ZombieLife=10, ZombieType=1, ZombieDamage=2, RewardCoins=3, RewardXP=3, ZombiePicture="/Content/Pictures/Zombies/SalesmanZombie.png"},
                new Zombie { ZombieName="Supermart", ZombieLife=12, ZombieType=1, ZombieDamage=3, RewardCoins=5, RewardXP=5, ZombiePicture="/Content/Pictures/Zombies/SupermartZombie.png"}
            };
            zombies.ForEach(s => context.Zombies.Add(s));
            context.SaveChanges();

            var materials = new List<Material> {
                new Material { ItemName="Toy gun", ItemType="material", ItemPicture="/Content/Pictures/Materials/ToyGun.png" },
                new Material { ItemName="Gasoline can", ItemType="material", ItemPicture="/Content/Pictures/Materials/GasolineCan.png" },
                new Material { ItemName="Duct tape", ItemType="material", ItemPicture="/Content/Pictures/Materials/DuctTape.png" },
                new Material { ItemName="Boxing gloves", ItemType="material", ItemPicture="/Content/Pictures/Materials/BoxingGloves.png" },
                new Material { ItemName="Motor oil", ItemType="material", ItemPicture="/Content/Pictures/Materials/MotorOil.png" },
                new Material { ItemName="Bowling ball", ItemType="material", ItemPicture="/Content/Pictures/Materials/BowlingBall.png" },
                new Material { ItemName="Rope", ItemType="material", ItemPicture="/Content/Pictures/Materials/Rope.png" },
                new Material { ItemName="Baseball Bat", ItemType="material", ItemPicture="/Content/Pictures/Materials/BaseballBat.png" },
                new Material { ItemName="Nail", ItemType="material", ItemPicture="/Content/Pictures/Materials/Nail.png" },
                new Material { ItemName="Liquor bottle", ItemType="material", ItemPicture="/Content/Pictures/Materials/LiquorBottle.png" },
                new Material { ItemName="Matches", ItemType="material", ItemPicture="/Content/Pictures/Materials/Matches.png" },
                new Material { ItemName="Suspenters", ItemType="material", ItemPicture="/Content/Pictures/Materials/Suspenders.png" },
                new Material { ItemName="Metal pipes", ItemType="material", ItemPicture="/Content/Pictures/Materials/.png" },
                new Material { ItemName="Garden trimmer", ItemType="material", ItemPicture="/Content/Pictures/Materials/GardenTrimmer.png" },
                new Material { ItemName="Dinner knife", ItemType="material", ItemPicture="/Content/Pictures/Materials/DinnerKnife.png" },
                new Material { ItemName="Dry ice", ItemType="material", ItemPicture="/Content/Pictures/Materials/DryIce.png" },
                new Material { ItemName="Fire extinguisher", ItemType="material", ItemPicture="/Content/Pictures/Materials/FireExtinguisher.png" },
                new Material { ItemName="Toilet paper", ItemType="material", ItemPicture="/Content/Pictures/Materials/ToiletPaper.png" }
            };
            materials.ForEach(s => context.Items.Add(s));
            context.SaveChanges();


            var zombieDrops = new List<ZombieDrop> {
                new ZombieDrop {ZombieID= 1, Material = new Material{ ItemID=34 }, MaterialPieces=1},
               /* new ZombieDrop {ZombieID= 1, MaterialID= 35, MaterialPieces=2},
                new ZombieDrop {ZombieID= 1, MaterialID= 35, MaterialPieces=2},
                new ZombieDrop {ZombieID= 1, MaterialID= 36, MaterialPieces=3},*/
            };
            zombieDrops.ForEach(s => context.ZombieDrops.Add(s));
            context.SaveChanges();

            var adventureDrops = new List<AdventureDrop> {
                new AdventureDrop { AdventureID=1, DropableItemID=7, ItemDroprate= 0.8, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=1, DropableItemID=8, ItemDroprate= 0.6, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=1, DropableItemID=9, ItemDroprate= 0.5, ItemMaxDrop=2 },
            };
            adventureDrops.ForEach(s => context.AdventureDrops.Add(s));
            context.SaveChanges();

            var buyableWeapons = new List<BuyableWeapon> {
                new BuyableWeapon { ItemName="Shovel", ItemDurability=999, ItemType="buyableWeapon", WeaponDamage=1, ItemPicture="/Content/Pictures/BuyableWeapons/Shovel.png"},
                new BuyableWeapon { ItemName="Katana", ItemDurability=999, ItemType="buyableWeapon", Cost=300, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
            };

            buyableWeapons.ForEach(s => context.Items.Add(s));
            context.SaveChanges();


            var craftableWeapons = new List<CraftableWeapon>
            {
                new CraftableWeapon { ItemName = "Fire Mitts", ItemType="craftableWeapon", WeaponDamage = 2, WeaponDurability=3, ItemPicture= "/Content/Pictures/CraftableWeapons/FireMitts.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=55, MaterialID=37, MaterialPieces=3},
                        new CraftableWeaponMaterial { WeaponID=55, MaterialID=38, MaterialPieces=3 },
                        new CraftableWeaponMaterial { WeaponID=55, MaterialID=2, MaterialPieces=1 }
                    }
                },
                new CraftableWeapon { ItemName = "Flamethrower", ItemType="craftableWeapon", WeaponDamage = 2, WeaponDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Flamethrower.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=59, MaterialID=34, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=59, MaterialID=35, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=59, MaterialID=36, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=59, MaterialID=2, MaterialPieces=1 }
                                       }
                }
            };
            craftableWeapons.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

        }
    }
}
