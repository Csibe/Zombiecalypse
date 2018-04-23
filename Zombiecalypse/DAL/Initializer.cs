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
                new Building{ItemName="House", BuildingLevel=1, ItemType="building", BuildingEnergyCost=0, ItemCost=0, ItemPicture="/Content/Pictures/Buildings/House_1.png"},
                new Building{ItemName="House", BuildingLevel=2, ItemType="building", BuildingEnergyCost=3, ItemCost=200, ItemPicture="/Content/Pictures/Buildings/House_2.png"},
                new Building{ItemName="House", BuildingLevel=3, ItemType="building", BuildingEnergyCost=4, ItemCost=300, ItemPicture="/Content/Pictures/Buildings/House_3.png"},
                new Building{ItemName="House", BuildingLevel=4, ItemType="building", BuildingEnergyCost=5, ItemCost=400, ItemPicture="/Content/Pictures/Buildings/House_4.png"},
                new Building{ItemName="House", BuildingLevel=5, ItemType="building", BuildingEnergyCost=5, ItemCost=400, ItemPicture="/Content/Pictures/Buildings/House_5.png"}
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
                new Adventure { AdventureName="Short Adventure", AdventureWaitingTime=10, AdventureXPBonus=6},
                new Adventure { AdventureName="Middle Adventure", AdventureWaitingTime=15, AdventureXPBonus=10}
            };
            adventures.ForEach(s => context.Adventures.Add(s));
            context.SaveChanges();


            var buildings2 = new List<Building>
                {
                new Building { ItemName = "Garage", BuildingLevel = 0, ItemDurability=0, ItemType = "building", BuildingEnergyCost = 0, ItemCost = 0, ItemPicture = "/Content/Pictures/Buildings/Garage_0.png" },
                new Building { ItemName = "Garage", BuildingLevel = 1, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_1.png" },
                new Building { ItemName = "Garage", BuildingLevel = 2, ItemDurability=3, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_2.png" },
                new Building { ItemName = "Garage", BuildingLevel = 3, ItemDurability=4, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_3.png" },
                new Building { ItemName = "Garage", BuildingLevel = 4, ItemDurability=5, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_4.png" },
                new Building { ItemName = "Garage", BuildingLevel = 5, ItemDurability=6, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_5.png" },

                new Building { ItemName = "GardenShed", BuildingLevel = 0, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 0, ItemCost = 0, ItemPicture = "/Content/Pictures/Buildings/GardenShed_0.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 1, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_1.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 2, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_2.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 3, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_3.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 4, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_4.png" },
                new Building { ItemName = "GardenShed", BuildingLevel = 5, ItemDurability=2, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_5.png" },

                new Building { ItemName = "ToolShed", BuildingLevel = 0, ItemType = "building", BuildingEnergyCost = 0, ItemCost = 0, ItemPicture = "/Content/Pictures/Buildings/ToolShed_0.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 1, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_1.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 2, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_2.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 3, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_3.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 4, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_4.png" },
                new Building { ItemName = "ToolShed", BuildingLevel = 5, ItemType = "building", BuildingEnergyCost = 5, ItemCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_5.png" },
                new Building{  ItemName="House", BuildingLevel=1, ItemType="building", BuildingEnergyCost=0, ItemCost=0, ItemPicture="/Content/Pictures/Buildings/House_1.png"},
            };
            buildings2.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var zombies = new List<Zombie> {
                new Zombie { ZombieName="Salesman", ZombieLife=1, ZombieType=1, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/SalesmanZombie.png"},
                new Zombie { ZombieName="Supermart", ZombieLife=1, ZombieType=1, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/SupermartZombie.png"},
                new Zombie { ZombieName="Janitor", ZombieLife=1, ZombieType=1, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/JanitorZombie.png"},
                new Zombie { ZombieName="Gas station", ZombieLife=2, ZombieType=2, ZombieDamage=2, RewardCoins=5, RewardXP=3, ZombiePicture="/Content/Pictures/Zombies/GasStationZombie.png"},
                new Zombie { ZombieName="Plumber", ZombieLife=2, ZombieType=2, ZombieDamage=2, RewardCoins=5, RewardXP=3, ZombiePicture="/Content/Pictures/Zombies/PlumberZombie.png"},
                new Zombie { ZombieName="Waitress", ZombieLife=2, ZombieType=2, ZombieDamage=2, RewardCoins=5, RewardXP=4, ZombiePicture="/Content/Pictures/Zombies/WaitressZombie.png"},
                new Zombie { ZombieName="Miner", ZombieLife=2, ZombieType=2, ZombieDamage=2, RewardCoins=6, RewardXP=6, ZombiePicture="/Content/Pictures/Zombies/MinerZombie.png"},
                new Zombie { ZombieName="Constructor", ZombieLife=4, ZombieType=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ConstructorZombie.png"},
                new Zombie { ZombieName="Firefighter", ZombieLife=4, ZombieType=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/FirefighterZombie.png"},
                new Zombie { ZombieName="Gardener", ZombieLife=4, ZombieType=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/GardenerZombie.png"},
                new Zombie { ZombieName="Hazmat", ZombieLife=4, ZombieType=3, ZombieDamage=2, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/HazmatZombie.png"},
                new Zombie { ZombieName="Cowboy", ZombieLife=4, ZombieType=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/CowboyZombie.png"},
                new Zombie { ZombieName="Sailor", ZombieLife=9, ZombieType=4, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/SailorZombie.png"},
                new Zombie { ZombieName="Riot", ZombieLife=8, ZombieType=5, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/RiotZombie.png"},
                new Zombie { ZombieName="Super soldier", ZombieLife=8, ZombieType=5, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/SuperSoldierZombie.png"}
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
                new Material { ItemName="Metal pipes", ItemType="material", ItemPicture="/Content/Pictures/Materials/MatalPipes.png" },
                new Material { ItemName="Garden trimmer", ItemType="material", ItemPicture="/Content/Pictures/Materials/GardenTrimmer.png" },
                new Material { ItemName="Dinner knife", ItemType="material", ItemPicture="/Content/Pictures/Materials/DinnerKnife.png" },
                new Material { ItemName="Dry ice", ItemType="material", ItemPicture="/Content/Pictures/Materials/DryIce.png" },
                new Material { ItemName="Fire extinguisher", ItemType="material", ItemPicture="/Content/Pictures/Materials/FireExtinguisher.png" },
                new Material { ItemName="Battery", ItemType="material", ItemPicture="/Content/Pictures/Materials/Battery.png" },
                new Material { ItemName="Rake", ItemType="material", ItemPicture="/Content/Pictures/Materials/Rake.png" },
                new Material { ItemName="Hose", ItemType="material", ItemPicture="/Content/Pictures/Materials/Hose.png" },

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

            var adventureDrops = new List<AdventureDrop> {
                new AdventureDrop { AdventureID=1, DropableItemID=7, ItemDroprate= 0.8, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=1, DropableItemID=8, ItemDroprate= 0.6, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=1, DropableItemID=9, ItemDroprate= 0.5, ItemMaxDrop=2 },
            };
            adventureDrops.ForEach(s => context.AdventureDrops.Add(s));
            context.SaveChanges();

            var weapon = new Weapon { ItemName = "Shovel", ItemDurability = 999, ItemType = "Weapon", WeaponDamage = 1, ItemPicture = "/Content/Pictures/BuyableWeapons/Shovel.png" };
            context.Weapons.Add(weapon);
            context.SaveChanges();

            var buyableWeapons = new List<BuyableWeapon> {
                new BuyableWeapon { ItemName="Katana", ItemDurability=999, ItemType="buyableWeapon", ItemCost=300, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
            };
            buyableWeapons.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var craftableWeapons = new List<CraftableWeapon>
            {
                new CraftableWeapon { ItemName = "Fire Mitts", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/FireMitts.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=58, MaterialID=36, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=58, MaterialID=38, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=58, MaterialID=2, MaterialPieces=1 }
                    }
                },
                new CraftableWeapon { ItemName = "Flamethrower", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Flamethrower.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=62, MaterialID=35, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=62, MaterialID=36, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=62, MaterialID=2, MaterialPieces=1 },

                    }
                },
                new CraftableWeapon { ItemName = "Electric Rake", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/ElectricRake.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=52, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=53, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=29, MaterialPieces=1 },
                                       }
                },
                new CraftableWeapon { ItemName = "Mega Maul", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/MegaMaul.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=40, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=41, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=29, MaterialPieces=1 },
                                       }
                },
                new CraftableWeapon { ItemName = "Crowd Controller", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/CrowdController.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=42, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=43, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                                       }
                },
                new CraftableWeapon { ItemName = "Fire Bomb", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/FireBomb.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=36, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=41, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                                       }
                },
                new CraftableWeapon { ItemName = "Molotov", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Molotov.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=44, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=45, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                                       }
                },
                new CraftableWeapon { ItemName = "Slingshot", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Slingshot.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=46, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=47, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                                       }
                },
                new CraftableWeapon { ItemName = "Zombie Trimmer", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/ZombieTrimmer.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=48, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=49, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=41, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                                       }
                },
                new CraftableWeapon { ItemName = "Ice Ice Baby", ItemType="craftableWeapon", WeaponDamage = 2, ItemDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/IceIceBaby.png",
                    WeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=50, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=51, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=54, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                                       }
                },
            };
            craftableWeapons.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            PlantField field = new PlantField { IsFieldEmpty = true, ItemType = "field", ItemName = "Field", ItemPicture = "/Content/Pictures/Fields/FieldEmpty.png" };
            context.Items.Add(field);
            context.SaveChanges();

            var plants = new List<Plant> {
                new Plant { ItemName="Strawberries",  ItemCost=15, GrowTime=5, PlantRewardCoin=30, PlantRewardFood=1, ItemType="plant", ItemPicture="/Content/Pictures/Fields/Corn.png",  PlantStartPicture= "/Content/Pictures/Fields/GarlicStart.png", PlantFinishedPicture="/Content/Pictures/Fields/GarlicFinished.png" },
                new Plant { ItemName="Radish", ItemCost=25, GrowTime=15, PlantRewardCoin=45, PlantRewardFood=1, ItemType="plant", ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/PotatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PotatoFinished.png" },
                new Plant { ItemName="Watermelon", ItemCost=50, GrowTime=60, PlantRewardCoin=70, PlantRewardFood=1, ItemType="plant", ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/CottonStart.png", PlantFinishedPicture="/Content/Pictures/Fields/CottonFinished.png"},
                new Plant { ItemName="Corn",  ItemCost=100, GrowTime=120, PlantRewardCoin=150, PlantRewardFood=3, ItemType="plant", ItemPicture="/Content/Pictures/Fields/Corn.png",    PlantStartPicture= "/Content/Pictures/Fields/GarlicStart.png", PlantFinishedPicture="/Content/Pictures/Fields/GarlicFinished.png" },
                new Plant { ItemName="Onion", ItemCost=110, GrowTime=360, PlantRewardCoin=190, PlantRewardFood=1, ItemType="plant", ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/PotatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PotatoFinished.png" },
                new Plant { ItemName="Peppers", ItemCost=350, GrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemType="plant", ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/CottonStart.png", PlantFinishedPicture="/Content/Pictures/Fields/CottonFinished.png"},
                new Plant { ItemName="Carrot",  ItemCost=220, GrowTime=720, PlantRewardCoin=350, PlantRewardFood=3, ItemType="plant",  ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture= "/Content/Pictures/Fields/GarlicStart.png", PlantFinishedPicture="/Content/Pictures/Fields/GarlicFinished.png" },
                new Plant { ItemName="Pumpkin", ItemCost=370, GrowTime=1440, PlantRewardCoin=585, PlantRewardFood=3, ItemType="plant", ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/PotatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PotatoFinished.png" },
                new Plant { ItemName="Beans", ItemCost=470, GrowTime=2880, PlantRewardCoin=880, PlantRewardFood=4, ItemType="plant", ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/CottonStart.png", PlantFinishedPicture="/Content/Pictures/Fields/CottonFinished.png"},
            };
            plants.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var weapons = new List<BuyableWeapon> {
                   new BuyableWeapon { ItemName="Shotgun", ItemDurability=10, ItemType="buyableWeapon", ItemCost=200, WeaponDamage=1, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                   new BuyableWeapon { ItemName="Hunting Riffle", ItemDurability=10, ItemType="buyableWeapon", ItemCost=800, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                   new BuyableWeapon { ItemName="Assault Riffle", ItemDurability=100, ItemType="buyableWeapon", ItemCost=7000, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                   new BuyableWeapon { ItemName="Mini-Gun", ItemDurability=20, ItemType="buyableWeapon", ItemCost=5000, WeaponDamage=4, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                   new BuyableWeapon { ItemName="Chin a Lake", ItemDurability=2, ItemType="buyableWeapon", ItemCost=8000, WeaponDamage=10, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                   new BuyableWeapon { ItemName="Bazooka", ItemDurability=1, ItemType="buyableWeapon", ItemCost=500, WeaponDamage=1, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                   new BuyableWeapon { ItemName="Crossbow", ItemDurability=10, ItemType="buyableWeapon", ItemCost=100, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                   new BuyableWeapon { ItemName="Flare Gun", ItemDurability=1, ItemType="buyableWeapon", ItemCost=2, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
               };


            weapons.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            var energies = new List<Energy> {
                new Energy { PlusEnergy = 1, ItemName = "Small energy pack",  ItemCost=65, ItemType="energy", ItemPicture = "/Content/Pictures/EnergyPacks/SmallEnergyPack.png" },
                new Energy { PlusEnergy = 3, ItemName = "Medium energy pack", ItemCost=100, ItemType="energy",ItemPicture = "/Content/Pictures/EnergyPacks/MediumEnergyPack.png" },
                new Energy { PlusEnergy = 5, ItemName = "Big energy pack", ItemCost=250, ItemType="energy", ItemPicture = "/Content/Pictures/EnergyPacks/BigEnergyPack.png" },
            };

            energies.ForEach(s => context.Energies.Add(s));
            context.SaveChanges();
        }
    }
}
