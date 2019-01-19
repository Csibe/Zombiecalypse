﻿using System;
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
                new Building{ItemID=2, ItemName="House", BuildingLevel=1, ItemMaxDurability=5, BuildingEnergyCost=0, BuildingMoneyCost=100, ItemPicture="/Content/Pictures/Buildings/House_1.png"},
                new Building{ItemID=3, ItemName="House", BuildingLevel=2, ItemMaxDurability=10, BuildingEnergyCost=3, BuildingMoneyCost=200, ItemPicture="/Content/Pictures/Buildings/House_2.png"},
                new Building{ItemID=4, ItemName="House", BuildingLevel=3, ItemMaxDurability=15, BuildingEnergyCost=4, BuildingMoneyCost=300, ItemPicture="/Content/Pictures/Buildings/House_3.png"},
                new Building{ItemID=5, ItemName="House", BuildingLevel=4, ItemMaxDurability=20, BuildingEnergyCost=5, BuildingMoneyCost=400, ItemPicture="/Content/Pictures/Buildings/House_4.png"},
                new Building{ItemID=6, ItemName="House", BuildingLevel=5, ItemMaxDurability=25, BuildingEnergyCost=5, BuildingMoneyCost=400, ItemPicture="/Content/Pictures/Buildings/House_5.png"},

                new Building {ItemID=7, ItemName = "Garage", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/Garage_0.png" },
                new Building {ItemID=8, ItemName = "Garage", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_1.png" },
                new Building {ItemID=9, ItemName = "Garage", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_2.png" },
                new Building {ItemID=10, ItemName = "Garage", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_3.png" },
                new Building {ItemID=11, ItemName = "Garage", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_4.png" },
                new Building {ItemID=12, ItemName = "Garage", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/Garage_5.png" },

                new Building {ItemID=13, ItemName = "Garden shed", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/GardenShed_0.png" },
                new Building {ItemID=14, ItemName = "Garden shed", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_1.png" },
                new Building {ItemID=15, ItemName = "Garden shed", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_2.png" },
                new Building {ItemID=16, ItemName = "Garden shed", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_3.png" },
                new Building {ItemID=17, ItemName = "Garden shed", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_4.png" },
                new Building {ItemID=18, ItemName = "Garden shed", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/GardenShed_5.png" },

                new Building {ItemID=19, ItemName = "Tool shed", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/ToolShed_0.png" },
                new Building {ItemID=20, ItemName = "Tool shed", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_1.png" },
                new Building {ItemID=21, ItemName = "Tool shed", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_2.png" },
                new Building {ItemID=22, ItemName = "Tool shed", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_3.png" },
                new Building {ItemID=23, ItemName = "Tool shed", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_4.png" },
                new Building {ItemID=24, ItemName = "Tool shed", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/ToolShed_5.png" },

                new Building {ItemID=82, ItemName = "Fence", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/82.png" },
                new Building {ItemID=83, ItemName = "Fence", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/83.png" },
                new Building {ItemID=84, ItemName = "Fence", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/84.png" },
                new Building {ItemID=85, ItemName = "Fence", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/85.png" },
                new Building {ItemID=86, ItemName = "Fence", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/86.png" },
                new Building {ItemID=87, ItemName = "Fence", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/87.png" },


                    };
            buildings.ForEach(s => context.Buildings.Add(s));
            context.SaveChanges();

            var plants = new List<Plant> {
                        new Plant {ItemID=25,  ItemName="Melon",  PlantMoneyCost=15, PlantGrowTime=5, PlantRewardCoin=30, PlantRewardFood=1, ItemPicture="/Content/Pictures/Fields/MelonFinished.png",  PlantStartPicture= "/Content/Pictures/Fields/MelonStart.png", PlantFinishedPicture="/Content/Pictures/Fields/MelonFinished.png" },
                        new Plant {ItemID=26,  ItemName="Pepper", PlantMoneyCost=25, PlantGrowTime=15, PlantRewardCoin=45, PlantRewardFood=1,  ItemPicture="/Content/Pictures/Fields/PepperFinished.png",   PlantStartPicture="/Content/Pictures/Fields/PepperStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PepperFinished.png" },
                        new Plant {ItemID=27,  ItemName="Potato", PlantMoneyCost=50, PlantGrowTime=60, PlantRewardCoin=70, PlantRewardFood=1, ItemPicture="/Content/Pictures/Fields/PotatoFinished.png",   PlantStartPicture="/Content/Pictures/Fields/PotatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PotatoFinished.png"},
                        new Plant {ItemID=28,  ItemName="Pumpkin",  PlantMoneyCost=100, PlantGrowTime=120, PlantRewardCoin=150, PlantRewardFood=3, ItemPicture="/Content/Pictures/Fields/PumpkinFinished.png",    PlantStartPicture= "/Content/Pictures/Fields/PumpkinStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PumpkinFinished.png" },
                        new Plant {ItemID=29,  ItemName="Strawberry", PlantMoneyCost=110, PlantGrowTime=360, PlantRewardCoin=190, PlantRewardFood=1, ItemPicture="/Content/Pictures/Fields/StrawberryFinished.png",   PlantStartPicture="/Content/Pictures/Fields/StrawberryStart.png", PlantFinishedPicture="/Content/Pictures/Fields/StrawberryFinished.png" },
                        new Plant {ItemID=30,  ItemName="Tomato", PlantMoneyCost=350, PlantGrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemPicture="/Content/Pictures/Fields/TomatoFinished.png",   PlantStartPicture="/Content/Pictures/Fields/TomatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/TomatoFinished.png"},

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
                        new Material {ItemID= 42, ItemName="Nails", ItemPicture="/Content/Pictures/Materials/Nails.png" },
                        new Material {ItemID= 43, ItemName="Liquor bottle", ItemPicture="/Content/Pictures/Materials/LiquorBottle.png" },
                        new Material {ItemID= 44, ItemName="Matches", ItemPicture="/Content/Pictures/Materials/Matches.png" },
                        new Material {ItemID= 45, ItemName="Suspenters", ItemPicture="/Content/Pictures/Materials/Suspenders.png" },
                        new Material {ItemID= 46, ItemName="Metal pipes", ItemPicture="/Content/Pictures/Materials/MetalPipes.png" },
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
                new BuildingMaterial {ItemID=56, ItemName="metal sheet", ItemPicture="/Content/Pictures/Items/MetalSheet.PNG"},
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
               //garden shed 0
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=54, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=55, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=56, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=57, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=13, BuildingMaterialID=58, MaterialPieces=0},

               //garden shed 1
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=54, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=55, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=56, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=57, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=14, BuildingMaterialID=58, MaterialPieces=1},

              //garden shed 2
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=54, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=55, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=56, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=57, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=15, BuildingMaterialID=58, MaterialPieces=2},
               //garden shed 3
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=54, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=55, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=56, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=57, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=16, BuildingMaterialID=58, MaterialPieces=3},
              //garden shed 4
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=54, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=55, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=56, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=57, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=17, BuildingMaterialID=58, MaterialPieces=4},
                //garden shed 5
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=54, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=55, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=56, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=57, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=18, BuildingMaterialID=58, MaterialPieces=5},


                //tool shed 0
                               new BuildingBuildingMaterial { BuildingID=19, BuildingMaterialID=54, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=19, BuildingMaterialID=55, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=19, BuildingMaterialID=56, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=19, BuildingMaterialID=57, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=19, BuildingMaterialID=58, MaterialPieces=0},

               //tool shed 1
                               new BuildingBuildingMaterial { BuildingID=20, BuildingMaterialID=54, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=20, BuildingMaterialID=55, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=20, BuildingMaterialID=56, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=20, BuildingMaterialID=57, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=20, BuildingMaterialID=58, MaterialPieces=1},

              //tool shed 2
                               new BuildingBuildingMaterial { BuildingID=21, BuildingMaterialID=54, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=21, BuildingMaterialID=55, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=21, BuildingMaterialID=56, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=21, BuildingMaterialID=57, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=21, BuildingMaterialID=58, MaterialPieces=2},
               //tool shed 3
                               new BuildingBuildingMaterial { BuildingID=22, BuildingMaterialID=54, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=22, BuildingMaterialID=55, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=22, BuildingMaterialID=56, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=22, BuildingMaterialID=57, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=22, BuildingMaterialID=58, MaterialPieces=3},
              //tool shed 4
                               new BuildingBuildingMaterial { BuildingID=23, BuildingMaterialID=54, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=23, BuildingMaterialID=55, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=23, BuildingMaterialID=56, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=23, BuildingMaterialID=57, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=23, BuildingMaterialID=58, MaterialPieces=4},
                //tool shed 5
                               new BuildingBuildingMaterial { BuildingID=24, BuildingMaterialID=54, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=24, BuildingMaterialID=55, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=24, BuildingMaterialID=56, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=24, BuildingMaterialID=57, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=24, BuildingMaterialID=58, MaterialPieces=5},

                                               //fence 1
                               new BuildingBuildingMaterial { BuildingID=83, BuildingMaterialID=54, MaterialPieces=5},


                                               //fence 2
                               new BuildingBuildingMaterial { BuildingID=84, BuildingMaterialID=54, MaterialPieces=10},


                                               //fence 3
                               new BuildingBuildingMaterial { BuildingID=85, BuildingMaterialID=54, MaterialPieces=15},


                                               //fence 4
                               new BuildingBuildingMaterial { BuildingID=86, BuildingMaterialID=54, MaterialPieces=20},


                                               //fence 5
                               new BuildingBuildingMaterial { BuildingID=87, BuildingMaterialID=54, MaterialPieces=25},


                        };

            buildingbuildingmaterials.ForEach(s => context.BuildingBuildingMaterials.Add(s));
            context.SaveChanges();

            var weapon = new Weapon { ItemID = 59, ItemName = "Shovel", ItemMaxDurability = 999, WeaponDamage = 1, ItemPicture = "/Content/Pictures/BuyableWeapons/Shovel.png" };
            context.Weapons.Add(weapon);
            context.SaveChanges();


            var buyableWeapons = new List<BuyableWeapon> {
                new BuyableWeapon {ItemID=60, ItemName="Katana", ItemMaxDurability=999,Cost=300, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png"},
                new BuyableWeapon {ItemID=61, ItemName="Shotgun", ItemMaxDurability=10, Cost=200, WeaponDamage=1, ItemPicture="/Content/Pictures/BuyableWeapons/Shotgun.png"},
                new BuyableWeapon {ItemID=62, ItemName="Hunting riffle", ItemMaxDurability=10, Cost=800, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/HuntingRiffle.png"},
                new BuyableWeapon {ItemID=63, ItemName="Assault riffle", ItemMaxDurability=100,  Cost=7000, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/AssaultRiffle.png"},
                new BuyableWeapon {ItemID=64, ItemName="Mini-gun", ItemMaxDurability=20, Cost=5000, WeaponDamage=4, ItemPicture="/Content/Pictures/BuyableWeapons/MiniGun.png"},
                new BuyableWeapon {ItemID=65, ItemName="Chin a lake", ItemMaxDurability=2,  Cost=8000, WeaponDamage=10, ItemPicture="/Content/Pictures/BuyableWeapons/ChinALake.png"},
                new BuyableWeapon {ItemID=66, ItemName="Bazooka", ItemMaxDurability=1, Cost=500, WeaponDamage=1, ItemPicture="/Content/Pictures/BuyableWeapons/Bazooka.png"},
                new BuyableWeapon {ItemID=67, ItemName="Chainsaw", ItemMaxDurability=10, Cost=100, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Chainsaw.png"},
                new BuyableWeapon {ItemID=68, ItemName="Ray gun", ItemMaxDurability=1, Cost=2, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/RayGun.png"},

            };
            buyableWeapons.ForEach(s => context.BuyableWeapons.Add(s));
            context.SaveChanges();

            var craftableWeapons = new List<CraftableWeapon>
            {
                new CraftableWeapon {ItemID=69, ItemName = "Fire Mitts", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/FireMitts.png",
                          CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=37, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=38, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=2, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=3, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=4, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=5, MaterialPieces=1 },
                        new CraftableWeaponMaterial { WeaponID=69, MaterialID=6, MaterialPieces=1 },
                    }
                },
                    new CraftableWeapon {ItemID=70, ItemName = "Flamethrower",  WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Flamethrower.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=34, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=35, MaterialPieces=1 },
                             new CraftableWeaponMaterial { WeaponID=70, MaterialID=3, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=4, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=5, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=6, MaterialPieces=1 },

                        }
                    },
                    new CraftableWeapon {ItemID=71, ItemName = "Electric Rake", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/ElectricRake.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=51, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=52, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=36, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=8, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=9, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=10, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=11, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=71, MaterialID=12, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=72, ItemName = "Mega Maul",  WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/MegaMaul.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=72, MaterialID=39, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=72, MaterialID=40, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=72, MaterialID=9, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=72, MaterialID=10, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=72, MaterialID=11, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=72, MaterialID=12, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=73, ItemName = "Crowd Controller", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/CrowdController.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=41, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=42, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=36, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=13, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=14, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=15, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=16, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=17, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=73, MaterialID=18, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=74, ItemName = "Fire Bomb", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/FireBomb.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=35, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=40, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=36, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=14, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=15, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=16, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=17, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=74, MaterialID=18, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=75, ItemName = "Molotov", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Molotov.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=75, MaterialID=43, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=75, MaterialID=44, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=75, MaterialID=36, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=75, MaterialID=20, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=75, MaterialID=21, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=75, MaterialID=22, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=75, MaterialID=23, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=75, MaterialID=24, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=76, ItemName = "Slingshot", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Slingshot.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=46, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=47, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=37, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=21, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=22, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=23, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=76, MaterialID=24, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=77, ItemName = "Zombie Trimmer", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/ZombieTrimmer.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=48, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=49, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=41, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=37, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=5, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=77, MaterialID=6, MaterialPieces=1 },
                                            }
                    },
                    new CraftableWeapon {ItemID=78, ItemName = "Ice Ice Baby", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/IceIceBaby.png",
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=50, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=51, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=54, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=37, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=17, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=78, MaterialID=18, MaterialPieces=1 },
                                            }
        }
    };
            craftableWeapons.ForEach(s => context.CraftableWeapons.Add(s));
            context.SaveChanges();

            var energies = new List<Energy> {
                            new Energy {ItemID=79, PlusEnergy = 3, ItemName = "Small energy pack", ItemMaxDurability=1,  Cost=3, ItemPicture = "/Content/Pictures/EnergyPacks/SmallEnergyPack.png" },
                            new Energy {ItemID=80, PlusEnergy = 10, ItemName = "Medium energy pack", ItemMaxDurability=1, Cost=5,ItemPicture = "/Content/Pictures/EnergyPacks/MediumEnergyPack.png" },
                            new Energy {ItemID=81, PlusEnergy = 20, ItemName = "Big energy pack", ItemMaxDurability=1, Cost=7, ItemPicture = "/Content/Pictures/EnergyPacks/BigEnergyPack.png" },
                        };

            energies.ForEach(s => context.Energies.Add(s));
            context.SaveChanges();


            var zombies = new List<Zombie> {
                //Base
                            new Zombie {ZombieID=1, ZombieName="Basic", ZombiePlaceAppear="Base", ZombieLife=1, ZombieRank=1, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/BasicZombie.png"},
                            new Zombie {ZombieID=2, ZombieName="Buckethead", ZombiePlaceAppear="Base", ZombieLife=1, ZombieRank=3, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/BucketheadZombie.png"},
                            new Zombie {ZombieID=3, ZombieName="Conehead", ZombiePlaceAppear="Base", ZombieLife=1, ZombieRank=1, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/ConeheadZombie.png"},
                            new Zombie {ZombieID=4, ZombieName="Flag", ZombiePlaceAppear="Base", ZombieLife=2, ZombieRank=2, ZombieDamage=2, RewardCoins=5, RewardXP=3, ZombiePicture="/Content/Pictures/Zombies/FlagZombie.png"},
                            new Zombie {ZombieID=5, ZombieName="Vase gargantuar", ZombiePlaceAppear="Base", ZombieLife=5, ZombieRank=5, ZombieDamage=2, RewardCoins=5, RewardXP=3, ZombiePicture="/Content/Pictures/Zombies/VaseGargantuar.png"},

                //Desert
                            new Zombie {ZombieID=6, ZombieName="Buckethead", ZombiePlaceAppear="Desert", ZombieLife=1, ZombieRank=1, ZombieDamage=2, RewardCoins=5, RewardXP=4, ZombiePicture="/Content/Pictures/Zombies/BucketheadMummy.png"},
                            new Zombie {ZombieID=7, ZombieName="Camel", ZombiePlaceAppear="Desert", ZombieLife=1, ZombieRank=1, ZombieDamage=2, RewardCoins=6, RewardXP=6, ZombiePicture="/Content/Pictures/Zombies/CamelZombies.png"},
                            new Zombie {ZombieID=8, ZombieName="Conehead", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=2, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ConeheadMummy.png"},
                            new Zombie {ZombieID=9, ZombieName="Egypt rally", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/EgyptRallyZombie.png"},
                            new Zombie {ZombieID=10, ZombieName="Explorer", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=1, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ExplorerZombie.png"},
                            new Zombie {ZombieID=11, ZombieName="Flag", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=2, ZombieDamage=2, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/FlagMummyZombie.png"},
                            new Zombie {ZombieID=12, ZombieName="Imp", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=1, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ImpMummy.png"},
                            new Zombie {ZombieID=13, ZombieName="Mummified gargantuar", ZombiePlaceAppear="Desert", ZombieLife=9, ZombieRank=5, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/MummifiedGargantuar.png"},
                            new Zombie {ZombieID=14, ZombieName="Mummy", ZombiePlaceAppear="Desert", ZombieLife=8, ZombieRank=1, ZombieDamage=1, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/MummyZombie.png"},
                            new Zombie {ZombieID=15, ZombieName="Pharoh", ZombiePlaceAppear="Desert", ZombieLife=8, ZombieRank=3, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/PharaohZombie.png"},
                            new Zombie {ZombieID=16, ZombieName="Pyramid-head", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=4, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/PyramidHeadZombie.png"},
                            new Zombie {ZombieID=17, ZombieName="Ra", ZombiePlaceAppear="Desert", ZombieLife=9, ZombieRank=2, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/RaZombie.png"},
                            new Zombie {ZombieID=18, ZombieName="Torchlight", ZombiePlaceAppear="Desert", ZombieLife=8, ZombieRank=2, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/TorchlightZombie.png"},
                            new Zombie {ZombieID=19, ZombieName="Zombot sphinxinator", ZombiePlaceAppear="Desert", ZombieLife=5, ZombieRank=5, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombotSphinxinator.png"},

                //Pirate Ship
                            new Zombie {ZombieID=20, ZombieName="Barrelhead", ZombieLife=2, ZombiePlaceAppear="Pirate", ZombieRank=3, ZombieDamage=2, RewardCoins=5, RewardXP=4, ZombiePicture="/Content/Pictures/Zombies/BucketheadCowboy.png"},
                            new Zombie {ZombieID=21, ZombieName="Barrel roller", ZombieLife=2, ZombiePlaceAppear="Pirate", ZombieRank=3, ZombieDamage=2, RewardCoins=6, RewardXP=6, ZombiePicture="/Content/Pictures/Zombies/Cart-HeadZombie.png"},
                            new Zombie {ZombieID=22, ZombieName="Bucket head", ZombieLife=4, ZombiePlaceAppear="Pirate", ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ChickenWranglerZombie.png"},
                            new Zombie {ZombieID=23, ZombieName="Conehead", ZombieLife=4, ZombiePlaceAppear="Pirate", ZombieRank=2, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ConeheadCowboy.png"},
                            new Zombie {ZombieID=24, ZombieName="Flag", ZombieLife=4, ZombiePlaceAppear="Pirate", ZombieRank=1, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/CowboyRallyZombie.png"},
                            new Zombie {ZombieID=25, ZombieName="Garganuar", ZombieLife=4, ZombiePlaceAppear="Pirate", ZombieRank=5, ZombieDamage=2, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/CowboyZombie.png"},
                            new Zombie {ZombieID=26, ZombieName="Imp cannon", ZombieLife=4, ZombiePlaceAppear="Pirate", ZombieRank=4, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/FlagCowboyZombie.png"},
                            new Zombie {ZombieID=27, ZombieName="Imp", ZombieLife=9, ZombiePlaceAppear="Pirate", ZombieRank=1, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/PianistZombie.png"},
                            new Zombie {ZombieID=28, ZombieName="Jolly roger", ZombieLife=8, ZombiePlaceAppear="Pirate", ZombieRank=2, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/PonchoZombie.png"},
                            new Zombie {ZombieID=29, ZombieName="Pelican", ZombieLife=8, ZombiePlaceAppear="Pirate", ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ProspectorZombie.png"},
                            new Zombie {ZombieID=30, ZombieName="Captain", ZombieLife=4, ZombiePlaceAppear="Pirate", ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/RodeoLegendZombie.png"},
                            new Zombie {ZombieID=31, ZombieName="Pirate", ZombieLife=9, ZombiePlaceAppear="Pirate", ZombieRank=2, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/WildWestGargantuar.png"},
                            new Zombie {ZombieID=32, ZombieName="Seagull", ZombieLife=8, ZombiePlaceAppear="Pirate", ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombieBull.png"},
                            new Zombie {ZombieID=33, ZombieName="Swashbuckler", ZombieLife=8, ZombiePlaceAppear="Pirate", ZombieRank=2, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombieBullRider.png"},
                            new Zombie {ZombieID=34, ZombieName="Parrot", ZombieLife=8, ZombiePlaceAppear="Pirate", ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombieChicken.png"},
                            new Zombie {ZombieID=35, ZombieName="Zombot plank walker", ZombiePlaceAppear="Pirate", ZombieLife=8, ZombieRank=5, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombotWarWagon.png"},

                    //Wild west
                            new Zombie {ZombieID=36, ZombieName="Buckethead", ZombiePlaceAppear="WildWest", ZombieLife=2, ZombieRank=3, ZombieDamage=2, RewardCoins=5, RewardXP=4, ZombiePicture="/Content/Pictures/Zombies/BucketheadCowboy.png"},
                            new Zombie {ZombieID=37, ZombieName="Cart-head", ZombiePlaceAppear="WildWest", ZombieLife=2, ZombieRank=3, ZombieDamage=2, RewardCoins=6, RewardXP=6, ZombiePicture="/Content/Pictures/Zombies/Cart-HeadZombie.png"},
                            new Zombie {ZombieID=38, ZombieName="Chicken weangler", ZombiePlaceAppear="WildWest", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ChickenWranglerZombie.png"},
                            new Zombie {ZombieID=39, ZombieName="Conehead", ZombiePlaceAppear="WildWest", ZombieLife=4, ZombieRank=2, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ConeheadCowboy.png"},
                            new Zombie {ZombieID=40, ZombieName="Cowboy rally", ZombiePlaceAppear="WildWest", ZombieLife=4, ZombieRank=1, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/CowboyRallyZombie.png"},
                            new Zombie {ZombieID=41, ZombieName="Cowboy", ZombiePlaceAppear="WildWest", ZombieLife=4, ZombieRank=5, ZombieDamage=2, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/CowboyZombie.png"},
                            new Zombie {ZombieID=42, ZombieName="Flag", ZombiePlaceAppear="WildWest", ZombieLife=4, ZombieRank=4, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/FlagCowboyZombie.png"},
                            new Zombie {ZombieID=43, ZombieName="Pianist", ZombiePlaceAppear="WildWest", ZombieLife=9, ZombieRank=1, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/PianistZombie.png"},
                            new Zombie {ZombieID=44, ZombieName="Poncho", ZombiePlaceAppear="WildWest", ZombieLife=8, ZombieRank=2, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/PonchoZombie.png"},
                            new Zombie {ZombieID=45, ZombieName="Prospector", ZombiePlaceAppear="WildWest", ZombieLife=8, ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ProspectorZombie.png"},
                            new Zombie {ZombieID=46, ZombieName="Rodeo legend", ZombiePlaceAppear="WildWest", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/RodeoLegendZombie.png"},
                            new Zombie {ZombieID=47, ZombieName="Wild west gargantuar", ZombiePlaceAppear="WildWest", ZombieLife=9, ZombieRank=2, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/WildWestGargantuar.png"},
                            new Zombie {ZombieID=48, ZombieName="Bull", ZombiePlaceAppear="WildWest", ZombieLife=8, ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombieBull.png"},
                            new Zombie {ZombieID=49, ZombieName="Bull rider", ZombiePlaceAppear="WildWest", ZombieLife=8, ZombieRank=2, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombieBullRider.png"},
                            new Zombie {ZombieID=50, ZombieName="Chicken", ZombiePlaceAppear="WildWest", ZombieLife=8, ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombieChicken.png"},
                            new Zombie {ZombieID=51, ZombieName="Zombot war wagon", ZombiePlaceAppear="WildWest", ZombieLife=8, ZombieRank=5, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombotWarWagon.png"},

                //Cave
                            new Zombie {ZombieID=52, ZombieName="Blockhead", ZombiePlaceAppear="Cave", ZombieLife=2, ZombieRank=3, ZombieDamage=2, RewardCoins=5, RewardXP=4, ZombiePicture="/Content/Pictures/Zombies/BlockheadZombie.png"},
                            new Zombie {ZombieID=53, ZombieName="Buckethead", ZombiePlaceAppear="Cave", ZombieLife=2, ZombieRank=3, ZombieDamage=2, RewardCoins=6, RewardXP=6, ZombiePicture="/Content/Pictures/Zombies/CaveBucketheadZombie.png"},
                            new Zombie {ZombieID=54, ZombieName="Conehead", ZombiePlaceAppear="Cave", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/CaveConeheadZombie.png"},
                            new Zombie {ZombieID=55, ZombieName="Flag", ZombiePlaceAppear="Cave", ZombieLife=4, ZombieRank=2, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/CaveFlagZombie.png"},
                            new Zombie {ZombieID=56, ZombieName="Cave", ZombiePlaceAppear="Cave", ZombieLife=4, ZombieRank=1, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/CaveZombie.png"},
                            new Zombie {ZombieID=57, ZombieName="Dodo rider", ZombiePlaceAppear="Cave", ZombieLife=4, ZombieRank=5, ZombieDamage=2, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/DodoRiderZombie.png"},
                            new Zombie {ZombieID=58, ZombieName="Hunter", ZombiePlaceAppear="Cave", ZombieLife=4, ZombieRank=4, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/HunterZombie.png"},
                            new Zombie {ZombieID=59, ZombieName="Ice weasel", ZombiePlaceAppear="Cave", ZombieLife=9, ZombieRank=1, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/IceWeasel.png"},
                            new Zombie {ZombieID=60, ZombieName="Sloth Gargantuar", ZombiePlaceAppear="Cave", ZombieLife=8, ZombieRank=2, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/SlothGargantuar.png"},
                            new Zombie {ZombieID=61, ZombieName="Troglobite", ZombiePlaceAppear="Cave", ZombieLife=8, ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/Troglobite.png"},
                            new Zombie {ZombieID=62, ZombieName="Weasel hoarer", ZombiePlaceAppear="Cave", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/WeaselHoarder.png"},
                            new Zombie {ZombieID=63, ZombieName="Yetilmp", ZombiePlaceAppear="Cave", ZombieLife=9, ZombieRank=2, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/YetiImp.png"},
                            new Zombie {ZombieID=64, ZombieName="Zombot tuskmaster", ZombiePlaceAppear="Cave", ZombieLife=8, ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombotTuskmaster10000BC.png"},
                  
                 //Lost City
                            new Zombie {ZombieID=65, ZombieName="Adventurer", ZombiePlaceAppear="LostCity", ZombieLife=2, ZombieRank=3, ZombieDamage=2, RewardCoins=5, RewardXP=4, ZombiePicture="/Content/Pictures/Zombies/AdventurerZombie.png"},
                            new Zombie {ZombieID=66, ZombieName="Buckethead", ZombiePlaceAppear="LostCity", ZombieLife=2, ZombieRank=3, ZombieDamage=2, RewardCoins=6, RewardXP=6, ZombiePicture="/Content/Pictures/Zombies/BuckethearAdventurerZombie.png"},
                            new Zombie {ZombieID=67, ZombieName="Bug", ZombiePlaceAppear="LostCity", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/BugZombie.png"},
                            new Zombie {ZombieID=68, ZombieName="Conehead", ZombiePlaceAppear="LostCity", ZombieLife=4, ZombieRank=2, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ConeheadAdventurerZombie.png"},
                            new Zombie {ZombieID=69, ZombieName="Excavator", ZombiePlaceAppear="LostCity", ZombieLife=4, ZombieRank=1, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ExcavatorZombie.png"},
                            new Zombie {ZombieID=70, ZombieName="Flag", ZombieLife=4, ZombiePlaceAppear="LostCity", ZombieRank=5, ZombieDamage=2, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/FlagAdventurerZombie.png"},
                            new Zombie {ZombieID=71, ZombieName="Imp porter", ZombiePlaceAppear="LostCity", ZombieLife=4, ZombieRank=4, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ImpPorter.png"},
                            new Zombie {ZombieID=72, ZombieName="Lost city imp", ZombiePlaceAppear="LostCity", ZombieLife=9, ZombieRank=1, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/LostCityImpZombie.png"},
                            new Zombie {ZombieID=73, ZombieName="Lost pilot", ZombiePlaceAppear="LostCity", ZombieLife=8, ZombieRank=2, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/LostPilotZombie.png"},
                            new Zombie {ZombieID=74, ZombieName="Parasol", ZombiePlaceAppear="LostCity", ZombieLife=8, ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ParasolZombie.png"},
                            new Zombie {ZombieID=75, ZombieName="Poter gargantuar", ZombiePlaceAppear="LostCity", ZombieLife=4, ZombieRank=3, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/PorterGargantuar.png"},
                            new Zombie {ZombieID=76, ZombieName="Relic hunter", ZombiePlaceAppear="LostCity", ZombieLife=9, ZombieRank=2, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/RelicHunterZombie.png"},
                            new Zombie {ZombieID=77, ZombieName="Turquoise Skull", ZombiePlaceAppear="LostCity", ZombieLife=8, ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/TurquoiseSkullZombie.png"},
                            new Zombie {ZombieID=78, ZombieName="Zombot aearostatic gondola",ZombiePlaceAppear="LostCity", ZombieLife=8, ZombieRank=1, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombotAerostaticGondola.png"},


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
                new AdventureDrop { AdventureID=1, DropableItemID=34, ItemDroprate= 0.2, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=1, DropableItemID=35, ItemDroprate= 0.1, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=1, DropableItemID=36, ItemDroprate= 0.3, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=1, DropableItemID=54, ItemDroprate= 0.2, ItemMaxDrop=1 },

                new AdventureDrop { AdventureID=2, DropableItemID=35, ItemDroprate= 0.25, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=2, DropableItemID=36, ItemDroprate= 0.18, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=2, DropableItemID=37, ItemDroprate= 0.25, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=2, DropableItemID=55, ItemDroprate= 0.2, ItemMaxDrop=1 },

                new AdventureDrop { AdventureID=3, DropableItemID=36, ItemDroprate= 0.3, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=3, DropableItemID=37, ItemDroprate= 0.2, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=3, DropableItemID=38, ItemDroprate= 0.16, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=3, DropableItemID=56, ItemDroprate= 0.2, ItemMaxDrop=1 },

                new AdventureDrop { AdventureID=4, DropableItemID=38, ItemDroprate= 0.17, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=4, DropableItemID=39, ItemDroprate= 0.2, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=4, DropableItemID=40, ItemDroprate= 0.14, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=4, DropableItemID=57, ItemDroprate= 0.2, ItemMaxDrop=1 },

                new AdventureDrop { AdventureID=5, DropableItemID=39, ItemDroprate= 0.11, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=5, DropableItemID=40, ItemDroprate= 0.16, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=5, DropableItemID=41, ItemDroprate= 0.18, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=5, DropableItemID=58, ItemDroprate= 0.2, ItemMaxDrop=1 },

                new AdventureDrop { AdventureID=6, DropableItemID=40, ItemDroprate= 0.2, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=6, DropableItemID=41, ItemDroprate= 0.13, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=6, DropableItemID=42, ItemDroprate= 0.17, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=6, DropableItemID=54, ItemDroprate= 0.4, ItemMaxDrop=2 },


                new AdventureDrop { AdventureID=7, DropableItemID=41, ItemDroprate= 0.2, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=7, DropableItemID=42, ItemDroprate= 0.13, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=7, DropableItemID=43, ItemDroprate= 0.17, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=7, DropableItemID=55, ItemDroprate= 0.4, ItemMaxDrop=2 },


                new AdventureDrop { AdventureID=8, DropableItemID=42, ItemDroprate= 0.2, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=8, DropableItemID=43, ItemDroprate= 0.13, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=8, DropableItemID=44, ItemDroprate= 0.17, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=8, DropableItemID=56, ItemDroprate= 0.4, ItemMaxDrop=2 },

                new AdventureDrop { AdventureID=9, DropableItemID=43, ItemDroprate= 0.2, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=9, DropableItemID=44, ItemDroprate= 0.13, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=9, DropableItemID=45, ItemDroprate= 0.17, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=9, DropableItemID=57, ItemDroprate= 0.4, ItemMaxDrop=2 },

                new AdventureDrop { AdventureID=10, DropableItemID=44, ItemDroprate= 0.2, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=10, DropableItemID=45, ItemDroprate= 0.13, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=10, DropableItemID=46, ItemDroprate= 0.17, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=10, DropableItemID=58, ItemDroprate= 0.4, ItemMaxDrop=2 },

                new AdventureDrop { AdventureID=11, DropableItemID=45, ItemDroprate= 0.2, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=11, DropableItemID=46, ItemDroprate= 0.13, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=11, DropableItemID=47, ItemDroprate= 0.17, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=11, DropableItemID=54, ItemDroprate= 0.4, ItemMaxDrop=2 },

                new AdventureDrop { AdventureID=12, DropableItemID=46, ItemDroprate= 0.2, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=12, DropableItemID=47, ItemDroprate= 0.13, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=12, DropableItemID=48, ItemDroprate= 0.17, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=12, DropableItemID=55, ItemDroprate= 0.4, ItemMaxDrop=2 },

                new AdventureDrop { AdventureID=13, DropableItemID=47, ItemDroprate= 0.2, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=13, DropableItemID=48, ItemDroprate= 0.13, ItemMaxDrop=3 },
                new AdventureDrop { AdventureID=13, DropableItemID=49, ItemDroprate= 0.17, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=13, DropableItemID=56, ItemDroprate= 0.4, ItemMaxDrop=2 },
            };

            adventureDrops.ForEach(s => context.AdventureDrops.Add(s));
            context.SaveChanges();


            var adventures = new List<Adventure> {
                 new Adventure { AdventureName="Short adventure", AdventureType="Base", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=3, AdventureZombieMaxRank=1, AdventureMaxZombiesPerRound=4, AdventureRequerdEnergy=3, CharacterLevelRequired = 1},
                 new Adventure { AdventureName="Desert adventure 1", AdventureType="Desert", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=2, AdventureZombieMaxRank=1, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4, CharacterLevelRequired=4},
                 new Adventure { AdventureName="Pirate ship adventure 2", AdventureType="Pirate", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureZombieMaxRank=1, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5, CharacterLevelRequired=7},
                 new Adventure { AdventureName="4. Adventure", AdventureType="WildWest", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=3, AdventureZombieMaxRank=1, AdventureMaxZombiesPerRound=4, AdventureRequerdEnergy=3, CharacterLevelRequired=11},
                 new Adventure { AdventureName="5. Adventure", AdventureType="Cave", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=4, AdventureZombieMaxRank=2, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4, CharacterLevelRequired=14},
                 new Adventure { AdventureName="6. Adventure", AdventureType="LostCity", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureZombieMaxRank=3, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5, CharacterLevelRequired=17},
                 new Adventure { AdventureName="7. Adventure", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=3, AdventureZombieMaxRank=1, AdventureMaxZombiesPerRound=4, AdventureRequerdEnergy=3, CharacterLevelRequired=19},
                 new Adventure { AdventureName="8. Adventure", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=4, AdventureZombieMaxRank=2, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4, CharacterLevelRequired=21},
                 new Adventure { AdventureName="9. Adventure", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureZombieMaxRank=3, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5, CharacterLevelRequired=24},
                 new Adventure { AdventureName="10. Adventure", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=3, AdventureZombieMaxRank=1, AdventureMaxZombiesPerRound=4, AdventureRequerdEnergy=3, CharacterLevelRequired=26},
                 new Adventure { AdventureName="11. Adventure", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=4, AdventureZombieMaxRank=2, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4, CharacterLevelRequired=29},
                 new Adventure { AdventureName="12. Adventure", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureZombieMaxRank=3, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5, CharacterLevelRequired=31},
                 new Adventure { AdventureName="13. Adventure", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureZombieMaxRank=3, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5, CharacterLevelRequired=33}

            };
            adventures.ForEach(s => context.Adventures.Add(s));
            context.SaveChanges();


            var dogs = new List<Dog> {
                 new Dog {  ItemID = 100, ItemName = "dog1", ItemPicture="/Content/Pictures/Dogs/dog1.png", ItemMaxDurability=0},
                 new Dog {  ItemID = 101, ItemName = "dog2", ItemPicture="/Content/Pictures/Dogs/dog2.png", ItemMaxDurability=0},
                 new Dog {  ItemID = 102, ItemName = "dog3", ItemPicture="/Content/Pictures/Dogs/dog3.png", ItemMaxDurability=0},
            };
            dogs.ForEach(s => context.Dogs.Add(s));
            context.SaveChanges();


        }
    }
}
