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



            var buildings = new List<Building>
                    {
                new Building{ItemID=1, ItemName="House", BuildingLevel=0, ItemMaxDurability=0, BuildingEnergyCost=0, BuildingMoneyCost=0, ItemPicture="/Content/Pictures/Buildings/House_0.png"},
                new Building{ItemID=2, ItemName="House", BuildingLevel=1, ItemMaxDurability=1, BuildingEnergyCost=0, BuildingMoneyCost=100, ItemPicture="/Content/Pictures/Buildings/House_1.png"},
                new Building{ItemID=3, ItemName="House", BuildingLevel=2, ItemMaxDurability=2, BuildingEnergyCost=3, BuildingMoneyCost=200, ItemPicture="/Content/Pictures/Buildings/House_2.png"},
                new Building{ItemID=4, ItemName="House", BuildingLevel=3, ItemMaxDurability=3, BuildingEnergyCost=4, BuildingMoneyCost=300, ItemPicture="/Content/Pictures/Buildings/House_3.png"},
                new Building{ItemID=5, ItemName="House", BuildingLevel=4, ItemMaxDurability=4, BuildingEnergyCost=5, BuildingMoneyCost=400, ItemPicture="/Content/Pictures/Buildings/House_4.png"},
                new Building{ItemID=6, ItemName="House", BuildingLevel=5, ItemMaxDurability=5, BuildingEnergyCost=5, BuildingMoneyCost=400, ItemPicture="/Content/Pictures/Buildings/House_5.png"},

                new Building {ItemID=7, ItemName = "Garage", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/Garage_0.png" },
                new Building {ItemID=8, ItemName = "Garage", BuildingLevel = 1, ItemMaxDurability=2, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_1.png" },
                new Building {ItemID=9, ItemName = "Garage", BuildingLevel = 2, ItemMaxDurability=3, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_2.png" },
                new Building {ItemID=10, ItemName = "Garage", BuildingLevel = 3, ItemMaxDurability=4, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_3.png" },
                new Building {ItemID=11, ItemName = "Garage", BuildingLevel = 4, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_4.png" },
                new Building {ItemID=12, ItemName = "Garage", BuildingLevel = 5, ItemMaxDurability=6, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_5.png" },

                new Building {ItemID=13, ItemName = "Garden shed", BuildingLevel = 0, ItemMaxDurability=2, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/GardenShed_0.png" },
                new Building {ItemID=14, ItemName = "Garden shed", BuildingLevel = 1, ItemMaxDurability=2, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_1.png" },
                new Building {ItemID=15, ItemName = "Garden shed", BuildingLevel = 2, ItemMaxDurability=2, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_2.png" },
                new Building {ItemID=16, ItemName = "Garden shed", BuildingLevel = 3, ItemMaxDurability=2, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_3.png" },
                new Building {ItemID=17, ItemName = "Garden shed", BuildingLevel = 4, ItemMaxDurability=2, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_4.png" },
                new Building {ItemID=18, ItemName = "Garden shed", BuildingLevel = 5, ItemMaxDurability=2, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_5.png" },

                new Building {ItemID=19, ItemName = "Tool shed", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/ToolShed_0.png" },
                new Building {ItemID=20, ItemName = "Tool shed", BuildingLevel = 1, ItemMaxDurability=1, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_1.png" },
                new Building {ItemID=21, ItemName = "Tool shed", BuildingLevel = 2, ItemMaxDurability=2, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_2.png" },
                new Building {ItemID=22, ItemName = "Tool shed", BuildingLevel = 3, ItemMaxDurability=3, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_3.png" },
                new Building {ItemID=23, ItemName = "Tool shed", BuildingLevel = 4, ItemMaxDurability=4, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_4.png" },
                new Building {ItemID=24, ItemName = "Tool shed", BuildingLevel = 5, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_5.png" },

                new Building {ItemID=82, ItemName = "Fence", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/Fence_0.png" },
                new Building {ItemID=83, ItemName = "Fence", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Fence_1.png" },
                new Building {ItemID=84, ItemName = "Fence", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Fence_2.png" },
                new Building {ItemID=85, ItemName = "Fence", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Fence_3.png" },
                new Building {ItemID=86, ItemName = "Fence", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Fence_4.png" },
                new Building {ItemID=87, ItemName = "Fence", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Fence_5.png" },
            

                    };
            buildings.ForEach(s => context.Buildings.Add(s));
            context.SaveChanges();

            var plants = new List<Plant> {
                        new Plant {ItemID=25,  ItemName="Strawberries",  PlantMoneyCost=15, PlantGrowTime=5, PlantRewardCoin=30, PlantRewardFood=1, ItemPicture="/Content/Pictures/Fields/Corn.png",  PlantStartPicture= "/Content/Pictures/Fields/GarlicStart.png", PlantFinishedPicture="/Content/Pictures/Fields/GarlicFinished.png" },
                        new Plant {ItemID=26,  ItemName="Radish", PlantMoneyCost=25, PlantGrowTime=15, PlantRewardCoin=45, PlantRewardFood=1,  ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/PotatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PotatoFinished.png" },
                        new Plant {ItemID=27,  ItemName="Watermelon", PlantMoneyCost=50, PlantGrowTime=60, PlantRewardCoin=70, PlantRewardFood=1, ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/CottonStart.png", PlantFinishedPicture="/Content/Pictures/Fields/CottonFinished.png"},
                        new Plant {ItemID=28,  ItemName="Corn",  PlantMoneyCost=100, PlantGrowTime=120, PlantRewardCoin=150, PlantRewardFood=3, ItemPicture="/Content/Pictures/Fields/Corn.png",    PlantStartPicture= "/Content/Pictures/Fields/GarlicStart.png", PlantFinishedPicture="/Content/Pictures/Fields/GarlicFinished.png" },
                        new Plant {ItemID=29,  ItemName="Onion", PlantMoneyCost=110, PlantGrowTime=360, PlantRewardCoin=190, PlantRewardFood=1, ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/PotatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PotatoFinished.png" },
                        new Plant {ItemID=30,  ItemName="Peppers", PlantMoneyCost=350, PlantGrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/CottonStart.png", PlantFinishedPicture="/Content/Pictures/Fields/CottonFinished.png"},
                        new Plant {ItemID=31,  ItemName="Carrot",  PlantMoneyCost=220, PlantGrowTime=720, PlantRewardCoin=350, PlantRewardFood=3, ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture= "/Content/Pictures/Fields/GarlicStart.png", PlantFinishedPicture="/Content/Pictures/Fields/GarlicFinished.png" },
                        new Plant {ItemID=32,  ItemName="Pumpkin", PlantMoneyCost=370, PlantGrowTime=1440, PlantRewardCoin=585, PlantRewardFood=3, ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/PotatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PotatoFinished.png" },
                        new Plant {ItemID=33,  ItemName="Beans", PlantMoneyCost=470, PlantGrowTime=2880, PlantRewardCoin=880, PlantRewardFood=4, ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/CottonStart.png", PlantFinishedPicture="/Content/Pictures/Fields/CottonFinished.png"},
                    };
            plants.ForEach(s => context.Plants.Add(s));
            context.SaveChanges();

            var materials = new List<Material> {
                        new Material {ItemID=34, ItemName="Toy gun", ItemPicture="/Content/Pictures/Materials/ToyGun.png" },
                        new Material {ItemID=35 , ItemName="Gasoline can", ItemPicture="/Content/Pictures/Materials/GasolineCan.png" },
                        new Material {ItemID=36 , ItemName="Duct tape", ItemPicture="/Content/Pictures/Materials/DuctTape.png" },
                        new Material {ItemID=37 , ItemName="Boxing gloves", ItemPicture="/Content/Pictures/Materials/BoxingGloves.png" },
                        new Material {ItemID= 38, ItemName="Motor oil", ItemPicture="/Content/Pictures/Materials/MotorOil.png" },
                        new Material {ItemID= 39, ItemName="Bowling ball", ItemPicture="/Content/Pictures/Materials/BowlingBall.png" },
                        new Material {ItemID= 40, ItemName="Rope", ItemPicture="/Content/Pictures/Materials/Rope.png" },
                        new Material {ItemID= 41, ItemName="Baseball Bat", ItemPicture="/Content/Pictures/Materials/BaseballBat.png" },
                        new Material {ItemID= 42, ItemName="Nail", ItemPicture="/Content/Pictures/Materials/Nail.png" },
                        new Material {ItemID= 43, ItemName="Liquor bottle", ItemPicture="/Content/Pictures/Materials/LiquorBottle.png" },
                        new Material {ItemID= 44, ItemName="Matches", ItemPicture="/Content/Pictures/Materials/Matches.png" },
                        new Material {ItemID= 45, ItemName="Suspenters", ItemPicture="/Content/Pictures/Materials/Suspenders.png" },
                        new Material {ItemID= 46, ItemName="Metal pipes", ItemPicture="/Content/Pictures/Materials/MatalPipes.png" },
                        new Material {ItemID= 47, ItemName="Garden trimmer",  ItemPicture="/Content/Pictures/Materials/GardenTrimmer.png" },
                        new Material {ItemID= 48, ItemName="Dinner knife", ItemPicture="/Content/Pictures/Materials/DinnerKnife.png" },
                        new Material {ItemID= 49, ItemName="Dry ice", ItemPicture="/Content/Pictures/Materials/DryIce.png" },
                        new Material {ItemID= 50, ItemName="Fire extinguisher", ItemPicture="/Content/Pictures/Materials/FireExtinguisher.png" },
                        new Material {ItemID= 51, ItemName="Battery", ItemPicture="/Content/Pictures/Materials/Battery.png" },
                        new Material {ItemID= 52, ItemName="Rake", ItemPicture="/Content/Pictures/Materials/Rake.png" },
                        new Material {ItemID= 53, ItemName="Hose", ItemPicture="/Content/Pictures/Materials/Hose.png" },

                        };
            materials.ForEach(s => context.Materials.Add(s));
            context.SaveChanges();

            var buildingmaterials = new List<BuildingMaterial>
                {
                new BuildingMaterial {ItemID=54, ItemName="blueprint", ItemPicture="/Content/Pictures/Items/Blueprint.PNG"},
                new BuildingMaterial {ItemID=55, ItemName="board", ItemPicture="/Content/Pictures/Items/Board.PNG"},
                new BuildingMaterial {ItemID=56, ItemName="metal shed", ItemPicture="/Content/Pictures/Items/MetalShed.PNG"},
                new BuildingMaterial {ItemID=57, ItemName="roof tile", ItemPicture="/Content/Pictures/Items/RoofTile.PNG"},
                new BuildingMaterial {ItemID=58, ItemName="screw",  ItemPicture="/Content/Pictures/Items/Screw.PNG"},
                };
            buildingmaterials.ForEach(s => context.BuildingMaterials.Add(s));
            context.SaveChanges();

            var buildingbuildingmaterials = new List<BuildingBuildingMaterial> {
                //house 0
                               new BuildingBuildingMaterial { BuildingID=1, BuildingMaterialID=54, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=1, BuildingMaterialID=55, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=1, BuildingMaterialID=56, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=1, BuildingMaterialID=57, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=1, BuildingMaterialID=58, MaterialPieces=0},
                //house 1
                               new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=54, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=55, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=56, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=57, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=58, MaterialPieces=1},
                //house 2
                               new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=54, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=55, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=56, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=57, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=58, MaterialPieces=2},
                //house 3
                               new BuildingBuildingMaterial { BuildingID=4, BuildingMaterialID=54, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=4, BuildingMaterialID=55, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=4, BuildingMaterialID=56, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=4, BuildingMaterialID=57, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=4, BuildingMaterialID=58, MaterialPieces=3},
                //house 4
                               new BuildingBuildingMaterial { BuildingID=5, BuildingMaterialID=54, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=5, BuildingMaterialID=55, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=5, BuildingMaterialID=56, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=5, BuildingMaterialID=57, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=5, BuildingMaterialID=58, MaterialPieces=4},
                //house 5
                               new BuildingBuildingMaterial { BuildingID=6, BuildingMaterialID=54, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=6, BuildingMaterialID=55, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=6, BuildingMaterialID=56, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=6, BuildingMaterialID=57, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=6, BuildingMaterialID=58, MaterialPieces=5},
                //garage 0
                               new BuildingBuildingMaterial { BuildingID=7, BuildingMaterialID=54, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=7, BuildingMaterialID=55, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=7, BuildingMaterialID=56, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=7, BuildingMaterialID=57, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=7, BuildingMaterialID=58, MaterialPieces=0},

               //garage 1
                               new BuildingBuildingMaterial { BuildingID=8, BuildingMaterialID=54, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=8, BuildingMaterialID=55, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=8, BuildingMaterialID=56, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=8, BuildingMaterialID=57, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=8, BuildingMaterialID=58, MaterialPieces=1},

               //garage 2
                               new BuildingBuildingMaterial { BuildingID=9, BuildingMaterialID=54, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=9, BuildingMaterialID=55, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=9, BuildingMaterialID=56, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=9, BuildingMaterialID=57, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=9, BuildingMaterialID=58, MaterialPieces=2},
                //garage 3
                               new BuildingBuildingMaterial { BuildingID=10, BuildingMaterialID=54, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=10, BuildingMaterialID=55, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=10, BuildingMaterialID=56, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=10, BuildingMaterialID=57, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=10, BuildingMaterialID=58, MaterialPieces=3},
                //garage 4
                               new BuildingBuildingMaterial { BuildingID=11, BuildingMaterialID=54, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=11, BuildingMaterialID=55, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=11, BuildingMaterialID=56, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=11, BuildingMaterialID=57, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=11, BuildingMaterialID=58, MaterialPieces=4},
                //garage  5
                               new BuildingBuildingMaterial { BuildingID=12, BuildingMaterialID=54, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=12, BuildingMaterialID=55, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=12, BuildingMaterialID=56, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=12, BuildingMaterialID=57, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=12, BuildingMaterialID=58, MaterialPieces=5},
               //toolshed 0
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=54, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=55, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=56, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=57, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=58, MaterialPieces=0},

               //toolshed 1
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=54, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=55, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=56, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=57, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=58, MaterialPieces=1},

               //toolshed 2
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=54, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=55, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=56, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=57, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=58, MaterialPieces=2},
                //toolshed 3
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=54, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=55, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=56, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=57, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=58, MaterialPieces=3},
                //toolshed 4
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=54, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=55, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=56, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=57, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=58, MaterialPieces=4},
                //toolshed 5
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=54, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=55, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=56, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=57, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=58, MaterialPieces=5},
                        };
            buildingbuildingmaterials.ForEach(s => context.BuildingBuildingMaterials.Add(s));
            context.SaveChanges();

            var weapon = new Weapon { ItemID = 59, ItemName = "Shovel", ItemMaxDurability = 999, WeaponDamage = 1, ItemPicture = "/Content/Pictures/BuyableWeapons/Shovel.png" };
            context.Weapons.Add(weapon);
            context.SaveChanges();


            var buyableWeapons = new List<BuyableWeapon> {
                new BuyableWeapon {ItemID=60, ItemName="Katana", ItemMaxDurability=999,Cost=300, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                new BuyableWeapon {ItemID=61, ItemName="Shotgun", ItemMaxDurability=10, Cost=200, WeaponDamage=1, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                new BuyableWeapon {ItemID=62, ItemName="Hunting Riffle", ItemMaxDurability=10, Cost=800, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                new BuyableWeapon {ItemID=63, ItemName="Assault Riffle", ItemMaxDurability=100,  Cost=7000, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                new BuyableWeapon {ItemID=64, ItemName="Mini-Gun", ItemMaxDurability=20, Cost=5000, WeaponDamage=4, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                new BuyableWeapon {ItemID=65, ItemName="Chin a Lake", ItemMaxDurability=2,  Cost=8000, WeaponDamage=10, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                new BuyableWeapon {ItemID=66, ItemName="Bazooka", ItemMaxDurability=1, Cost=500, WeaponDamage=1, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                new BuyableWeapon {ItemID=67, ItemName="Crossbow", ItemMaxDurability=10, Cost=100, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                new BuyableWeapon {ItemID=68, ItemName="Flare Gun", ItemMaxDurability=1, Cost=2, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},

            };
            buyableWeapons.ForEach(s => context.BuyableWeapons.Add(s));
            context.SaveChanges();

            var craftableWeapons = new List<CraftableWeapon>
            {
                new CraftableWeapon {ItemID=69, ItemName = "Fire Mitts", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/FireMitts.png",
                          CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=36, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=38, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=2, MaterialPieces=1 }
                    }
                },
                    new CraftableWeapon {ItemID=70, ItemName = "Flamethrower",  WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Flamethrower.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=35, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=36, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=2, MaterialPieces=1 },

                        }
                    },
                    new CraftableWeapon {ItemID=71, ItemName = "Electric Rake", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/ElectricRake.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=52, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=53, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=37, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=29, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=72, ItemName = "Mega Maul",  WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/MegaMaul.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=72, MaterialID=40, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=72, MaterialID=41, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=72, MaterialID=29, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=73, ItemName = "Crowd Controller", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/CrowdController.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=42, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=43, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=37, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=37, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=74, ItemName = "Fire Bomb", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/FireBomb.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=36, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=37, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=41, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=37, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=75, ItemName = "Molotov", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Molotov.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=64, MaterialID=44, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=64, MaterialID=45, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=64, MaterialID=37, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=76, ItemName = "Slingshot", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Slingshot.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=46, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=47, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=37, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=37, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=77, ItemName = "Zombie Trimmer", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/ZombieTrimmer.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=48, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=49, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=41, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=37, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=78, ItemName = "Ice Ice Baby", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/IceIceBaby.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=50, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=51, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=54, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=37, MaterialPieces=1 },
                                            }
        }
    };
            craftableWeapons.ForEach(s => context.CraftableWeapons.Add(s));
            context.SaveChanges();

            var energies = new List<Energy> {
                            new Energy {ItemID=79, PlusEnergy = 1, ItemName = "Small energy pack", ItemMaxDurability=1,  Cost=65, ItemPicture = "/Content/Pictures/EnergyPacks/SmallEnergyPack.png" },
                            new Energy {ItemID=80, PlusEnergy = 3, ItemName = "Medium energy pack", ItemMaxDurability=1, Cost=100,ItemPicture = "/Content/Pictures/EnergyPacks/MediumEnergyPack.png" },
                            new Energy {ItemID=81, PlusEnergy = 5, ItemName = "Big energy pack", ItemMaxDurability=1, Cost=250, ItemPicture = "/Content/Pictures/EnergyPacks/BigEnergyPack.png" },
                        };

            energies.ForEach(s => context.Energies.Add(s));
            context.SaveChanges();


            var zombies = new List<Zombie> {
                            new Zombie {ZombieID=1, ZombieName="Salesman", ZombieLife=1, ZombieRank=1, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/SalesmanZombie.png"},
                            new Zombie {ZombieID=2, ZombieName="Supermart", ZombieLife=1, ZombieRank=1, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/SupermartZombie.png"},
                            new Zombie {ZombieID=3, ZombieName="Janitor", ZombieLife=1, ZombieRank=1, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/JanitorZombie.png"},
                            new Zombie {ZombieID=4, ZombieName="Gas station", ZombieLife=2, ZombieRank=2, ZombieDamage=2, RewardCoins=5, RewardXP=3, ZombiePicture="/Content/Pictures/Zombies/GasStationZombie.png"},
                            new Zombie {ZombieID=5, ZombieName="Plumber", ZombieLife=2, ZombieRank=2, ZombieDamage=2, RewardCoins=5, RewardXP=3, ZombiePicture="/Content/Pictures/Zombies/PlumberZombie.png"},
                            new Zombie {ZombieID=6, ZombieName="Waitress", ZombieLife=2, ZombieRank=2, ZombieDamage=2, RewardCoins=5, RewardXP=4, ZombiePicture="/Content/Pictures/Zombies/WaitressZombie.png"},
                            new Zombie {ZombieID=7, ZombieName="Miner", ZombieLife=2, ZombieRank=2, ZombieDamage=2, RewardCoins=6, RewardXP=6, ZombiePicture="/Content/Pictures/Zombies/MinerZombie.png"},
                            new Zombie {ZombieID=8, ZombieName="Constructor", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ConstructorZombie.png"},
                            new Zombie {ZombieID=9, ZombieName="Firefighter", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/FirefighterZombie.png"},
                            new Zombie {ZombieID=10, ZombieName="Gardener", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/GardenerZombie.png"},
                            new Zombie {ZombieID=11, ZombieName="Hazmat", ZombieLife=4, ZombieRank=3, ZombieDamage=2, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/HazmatZombie.png"},
                            new Zombie {ZombieID=12, ZombieName="Cowboy", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/CowboyZombie.png"},
                            new Zombie {ZombieID=13, ZombieName="Sailor", ZombieLife=9, ZombieRank=4, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/SailorZombie.png"},
                            new Zombie {ZombieID=14, ZombieName="Riot", ZombieLife=8, ZombieRank=5, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/RiotZombie.png"},
                            new Zombie {ZombieID=15, ZombieName="Super soldier", ZombieLife=8, ZombieRank=5, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/SuperSoldierZombie.png"}
                        };
            zombies.ForEach(s => context.Zombies.Add(s));
            context.SaveChanges();



            var zombieDrops = new List<ZombieDrop> {
                            new ZombieDrop {ZombieID= 1, MaterialID= 34, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 1, MaterialID= 40, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 1, MaterialID= 38, MaterialPieces=3},
                            new ZombieDrop {ZombieID= 1, MaterialID= 54, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 1, MaterialID= 79, MaterialPieces=2},

                            new ZombieDrop {ZombieID= 2, MaterialID= 34, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 2, MaterialID= 40, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 2, MaterialID= 38, MaterialPieces=3},
                            new ZombieDrop {ZombieID= 2, MaterialID= 79, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 2, MaterialID= 54, MaterialPieces=2},

                            new ZombieDrop {ZombieID= 3, MaterialID= 57, MaterialPieces=2},

                            new ZombieDrop {ZombieID= 4, MaterialID= 51, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 4, MaterialID= 35, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 4, MaterialID= 53, MaterialPieces=2},

                            new ZombieDrop {ZombieID= 5, MaterialID= 45, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 5, MaterialID= 46, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 5, MaterialID= 54, MaterialPieces=2},

                            new ZombieDrop {ZombieID= 6, MaterialID= 49, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 6, MaterialID= 48, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 6, MaterialID= 43, MaterialPieces=2},

                           //SEMMI
                            new ZombieDrop {ZombieID= 7, MaterialID= 49, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 7, MaterialID= 48, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 7, MaterialID= 43, MaterialPieces=2},


                            new ZombieDrop {ZombieID= 8, MaterialID= 42, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 8, MaterialID= 45, MaterialPieces=2},

                            new ZombieDrop {ZombieID= 9, MaterialID= 50, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 9, MaterialID= 44, MaterialPieces=2},

                            //SEMMI
                            new ZombieDrop {ZombieID= 10, MaterialID= 50, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 10, MaterialID= 44, MaterialPieces=2},

                            new ZombieDrop {ZombieID=11, MaterialID= 51, MaterialPieces=2},

                            //SEMMI
                            new ZombieDrop {ZombieID= 12, MaterialID= 50, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 12, MaterialID= 44, MaterialPieces=2},

                            //SEMMI
                            new ZombieDrop {ZombieID= 13, MaterialID= 50, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 13, MaterialID= 44, MaterialPieces=2},

                            //SEMMI
                            new ZombieDrop {ZombieID= 14, MaterialID= 50, MaterialPieces=2},
                            new ZombieDrop {ZombieID= 14, MaterialID= 44, MaterialPieces=2},


            };
            zombieDrops.ForEach(s => context.ZombieDrops.Add(s));
            context.SaveChanges();

            var adventureDrops = new List<AdventureDrop> {
                new AdventureDrop { AdventureID=1, DropableItemID=34, ItemDroprate= 0.8, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=1, DropableItemID=35, ItemDroprate= 0.6, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=1, DropableItemID=36, ItemDroprate= 0.5, ItemMaxDrop=2 },
            };
            adventureDrops.ForEach(s => context.AdventureDrops.Add(s));
            context.SaveChanges();


            var adventures = new List<Adventure> {
                 new Adventure { AdventureName="Short Adventure", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=3, AdventureZombieMaxRank=1, AdventureMaxZombiesPerRound=4, AdventureRequerdEnergy=3},
                 new Adventure { AdventureName="Middle Adventure", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=4, AdventureZombieMaxRank=2, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4},
                 new Adventure { AdventureName="Third Adventure", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureZombieMaxRank=3, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5}
            };
            adventures.ForEach(s => context.Adventures.Add(s));
            context.SaveChanges();




        }
    }
}
