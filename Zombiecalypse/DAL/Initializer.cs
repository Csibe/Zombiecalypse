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
                new Building{ItemID=1, ItemName="House", BuildingLevel=0, ItemMaxDurability=0, BuildingEnergyCost=0, BuildingMoneyCost=0, ItemPicture="/Content/Pictures/Buildings/1.png"},
                new Building{ItemID=2, ItemName="House", BuildingLevel=1, ItemMaxDurability=5, BuildingEnergyCost=0, BuildingMoneyCost=100, ItemPicture="/Content/Pictures/Buildings/2.png"},
                new Building{ItemID=3, ItemName="House", BuildingLevel=2, ItemMaxDurability=10, BuildingEnergyCost=3, BuildingMoneyCost=200, ItemPicture="/Content/Pictures/Buildings/3.png"},
                new Building{ItemID=4, ItemName="House", BuildingLevel=3, ItemMaxDurability=15, BuildingEnergyCost=4, BuildingMoneyCost=300, ItemPicture="/Content/Pictures/Buildings/4.png"},
                new Building{ItemID=5, ItemName="House", BuildingLevel=4, ItemMaxDurability=20, BuildingEnergyCost=5, BuildingMoneyCost=400, ItemPicture="/Content/Pictures/Buildings/5.png"},
                new Building{ItemID=6, ItemName="House", BuildingLevel=5, ItemMaxDurability=25, BuildingEnergyCost=5, BuildingMoneyCost=400, ItemPicture="/Content/Pictures/Buildings/6.png"},

                new Building {ItemID=7, ItemName = "Garage", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/7.png" },
                new Building {ItemID=8, ItemName = "Garage", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/8.png" },
                new Building {ItemID=9, ItemName = "Garage", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/9.png" },
                new Building {ItemID=10, ItemName = "Garage", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/10.png" },
                new Building {ItemID=11, ItemName = "Garage", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/11.png" },
                new Building {ItemID=12, ItemName = "Garage", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/12.png" },

                new Building {ItemID=13, ItemName = "Garden shed", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/13.png" },
                new Building {ItemID=14, ItemName = "Garden shed", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/14.png" },
                new Building {ItemID=15, ItemName = "Garden shed", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/15.png" },
                new Building {ItemID=16, ItemName = "Garden shed", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/16.png" },
                new Building {ItemID=17, ItemName = "Garden shed", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/17.png" },
                new Building {ItemID=18, ItemName = "Garden shed", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/18.png" },

                new Building {ItemID=19, ItemName = "Tool shed", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/19.png" },
                new Building {ItemID=20, ItemName = "Tool shed", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/20.png" },
                new Building {ItemID=21, ItemName = "Tool shed", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/21.png" },
                new Building {ItemID=22, ItemName = "Tool shed", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/22.png" },
                new Building {ItemID=23, ItemName = "Tool shed", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/23.png" },
                new Building {ItemID=24, ItemName = "Tool shed", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/24.png" },

                new Building {ItemID=82, ItemName = "Fence", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/82.png" },
                new Building {ItemID=83, ItemName = "Fence", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/83.png" },
                new Building {ItemID=84, ItemName = "Fence", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/84.png" },
                new Building {ItemID=85, ItemName = "Fence", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/85.png" },
                new Building {ItemID=86, ItemName = "Fence", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/86.png" },
                new Building {ItemID=87, ItemName = "Fence", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/87.png" },

                new Building {ItemID=88, ItemName = "Car", BuildingLevel = 0, ItemMaxDurability=0, BuildingEnergyCost = 0, BuildingMoneyCost = 0, ItemPicture = "/Content/Pictures/Buildings/88.png" },
                new Building {ItemID=89, ItemName = "Car", BuildingLevel = 1, ItemMaxDurability=5, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/89.png" },
                new Building {ItemID=90, ItemName = "Car", BuildingLevel = 2, ItemMaxDurability=10, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/90.png" },
                new Building {ItemID=91, ItemName = "Car", BuildingLevel = 3, ItemMaxDurability=15, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/91.png" },
                new Building {ItemID=92, ItemName = "Car", BuildingLevel = 4, ItemMaxDurability=20, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/92.png" },
                new Building {ItemID=93, ItemName = "Car", BuildingLevel = 5, ItemMaxDurability=25, BuildingEnergyCost = 5, BuildingMoneyCost = 400, ItemPicture = "/Content/Pictures/Buildings/93.png" },


                    };
            buildings.ForEach(s => context.Buildings.Add(s));
            context.SaveChanges();

            var plants = new List<Plant> {
                        new Plant {ItemID=25,  ItemName="Melon", RequiredLevel = 1,  PlantMoneyCost=20, PlantGrowTime=5, PlantRewardCoin=30, PlantRewardFood=1, ItemPicture="/Content/Pictures/Fields/MelonFinished.png",  PlantStartPicture= "/Content/Pictures/Fields/MelonStart.png", PlantFinishedPicture="/Content/Pictures/Fields/MelonFinished.png" },
                        new Plant {ItemID=26,  ItemName="Pepper",  RequiredLevel = 3,  PlantMoneyCost=40, PlantGrowTime=15, PlantRewardCoin=55, PlantRewardFood=1,  ItemPicture="/Content/Pictures/Fields/PepperFinished.png",   PlantStartPicture="/Content/Pictures/Fields/PepperStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PepperFinished.png" },
                        new Plant {ItemID=27,  ItemName="Potato",  RequiredLevel= 5, PlantMoneyCost=50, PlantGrowTime=60, PlantRewardCoin=70, PlantRewardFood=1, ItemPicture="/Content/Pictures/Fields/PotatoFinished.png",   PlantStartPicture="/Content/Pictures/Fields/PotatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PotatoFinished.png"},
                        new Plant {ItemID=28,  ItemName="Pumpkin",  RequiredLevel= 7, PlantMoneyCost=100, PlantGrowTime=120, PlantRewardCoin=150, PlantRewardFood=3, ItemPicture="/Content/Pictures/Fields/PumpkinFinished.png",    PlantStartPicture= "/Content/Pictures/Fields/PumpkinStart.png", PlantFinishedPicture="/Content/Pictures/Fields/PumpkinFinished.png" },
                        new Plant {ItemID=29,  ItemName="Strawberry", RequiredLevel= 9, PlantMoneyCost=110, PlantGrowTime=360, PlantRewardCoin=190, PlantRewardFood=1, ItemPicture="/Content/Pictures/Fields/StrawberryFinished.png",   PlantStartPicture="/Content/Pictures/Fields/StrawberryStart.png", PlantFinishedPicture="/Content/Pictures/Fields/StrawberryFinished.png" },
                        new Plant {ItemID=30,  ItemName="Tomato", RequiredLevel= 11, PlantMoneyCost=350, PlantGrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemPicture="/Content/Pictures/Fields/TomatoFinished.png",   PlantStartPicture="/Content/Pictures/Fields/TomatoStart.png", PlantFinishedPicture="/Content/Pictures/Fields/TomatoFinished.png"},
                        new Plant {ItemID=101,  ItemName="Carrot", RequiredLevel= 13, PlantMoneyCost=350, PlantGrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemPicture="/Content/Pictures/Fields/Carrot.png",   PlantStartPicture="/Content/Pictures/Fields/Carrot.png", PlantFinishedPicture="/Content/Pictures/Fields/Carrot.png"},
                        new Plant {ItemID=102,  ItemName="Corn", RequiredLevel= 15, PlantMoneyCost=350, PlantGrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemPicture="/Content/Pictures/Fields/Corn.png",   PlantStartPicture="/Content/Pictures/Fields/Corn.png", PlantFinishedPicture="/Content/Pictures/Fields/Corn.png"},
                        new Plant {ItemID=103,  ItemName="Rice", RequiredLevel= 17, PlantMoneyCost=350, PlantGrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemPicture="/Content/Pictures/Fields/Rice.png",   PlantStartPicture="/Content/Pictures/Fields/Rice.png", PlantFinishedPicture="/Content/Pictures/Fields/Rice.png"},
                        new Plant {ItemID=104,  ItemName="Cotton", RequiredLevel= 19, PlantMoneyCost=350, PlantGrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemPicture="/Content/Pictures/Fields/Cotton.png",   PlantStartPicture="/Content/Pictures/Fields/Cotton.png", PlantFinishedPicture="/Content/Pictures/Fields/Cotton.png"},
                        new Plant {ItemID=105,  ItemName="Coffee", RequiredLevel= 21, PlantMoneyCost=350, PlantGrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemPicture="/Content/Pictures/Fields/Coffee_Plant.png",   PlantStartPicture="/Content/Pictures/Fields/Coffee_Plant.png", PlantFinishedPicture="/Content/Pictures/Fields/Coffee_Plant.png"},
                        new Plant {ItemID=106,  ItemName="Cacao", RequiredLevel= 23, PlantMoneyCost=350, PlantGrowTime=480, PlantRewardCoin=526, PlantRewardFood=2, ItemPicture="/Content/Pictures/Fields/Cacao.png",   PlantStartPicture="/Content/Pictures/Fields/Cacao.png", PlantFinishedPicture="/Content/Pictures/Fields/Cacao.png"},


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
                        new Material {ItemID= 99, ItemName="Fertilizer", ItemPicture="/Content/Pictures/Materials/Fertilizer.png" },
                        new Material {ItemID= 100, ItemName="Metal bucket", ItemPicture="/Content/Pictures/Materials/MetalBucket.png" },

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
                new BuildingMaterial {ItemID=94, ItemName="brick",  ItemPicture="/Content/Pictures/Items/Brick.PNG"},
                new BuildingMaterial {ItemID= 95, ItemName="Car wax", ItemPicture="/Content/Pictures/Items/CarWax.png" },
                new BuildingMaterial {ItemID= 96, ItemName="Spare parts", ItemPicture="/Content/Pictures/Items/SpareParts.png" },
                new BuildingMaterial {ItemID= 97, ItemName="Spare plugs", ItemPicture="/Content/Pictures/Items/SparePlugs.png" },
                new BuildingMaterial {ItemID= 98, ItemName="jumper cable", ItemPicture="/Content/Pictures/Items/JumperCable.png" },
                };
            buildingmaterials.ForEach(s => context.BuildingMaterials.Add(s));
            context.SaveChanges();

            var buildingbuildingmaterials = new List<BuildingBuildingMaterial> {
                //house 0
                               new BuildingBuildingMaterial { BuildingID=1, BuildingMaterialID=94, MaterialPieces=0},
                //house 1
                               new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=94, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=2, BuildingMaterialID=54, MaterialPieces=1},
                //house 2
                               new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=94, MaterialPieces=7},
                               new BuildingBuildingMaterial { BuildingID=3, BuildingMaterialID=55, MaterialPieces=2},

                //house 3
                               new BuildingBuildingMaterial { BuildingID=4, BuildingMaterialID=94, MaterialPieces=10},
                               new BuildingBuildingMaterial { BuildingID=4, BuildingMaterialID=55, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=4, BuildingMaterialID=56, MaterialPieces=3},

                //house 4
                               new BuildingBuildingMaterial { BuildingID=5, BuildingMaterialID=94, MaterialPieces=15},
                               new BuildingBuildingMaterial { BuildingID=5, BuildingMaterialID=55, MaterialPieces=7},
                               new BuildingBuildingMaterial { BuildingID=5, BuildingMaterialID=56, MaterialPieces=5},

                //house 5
                               new BuildingBuildingMaterial { BuildingID=6, BuildingMaterialID=94, MaterialPieces=23},
                               new BuildingBuildingMaterial { BuildingID=6, BuildingMaterialID=57, MaterialPieces=11},
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


                                               //car 0
                               new BuildingBuildingMaterial { BuildingID=88, BuildingMaterialID=95, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=88, BuildingMaterialID=96, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=88, BuildingMaterialID=97, MaterialPieces=0},
                               new BuildingBuildingMaterial { BuildingID=88, BuildingMaterialID=98, MaterialPieces=0},
                                               //car 1
                               new BuildingBuildingMaterial { BuildingID=89, BuildingMaterialID=95, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=89, BuildingMaterialID=96, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=89, BuildingMaterialID=97, MaterialPieces=1},
                               new BuildingBuildingMaterial { BuildingID=89, BuildingMaterialID=98, MaterialPieces=1},
                                               //car 2
                               new BuildingBuildingMaterial { BuildingID=90, BuildingMaterialID=95, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=90, BuildingMaterialID=96, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=90, BuildingMaterialID=97, MaterialPieces=2},
                               new BuildingBuildingMaterial { BuildingID=90, BuildingMaterialID=98, MaterialPieces=2},
                                               //car 3
                               new BuildingBuildingMaterial { BuildingID=91, BuildingMaterialID=95, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=91, BuildingMaterialID=96, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=91, BuildingMaterialID=97, MaterialPieces=3},
                               new BuildingBuildingMaterial { BuildingID=91, BuildingMaterialID=98, MaterialPieces=3},
                                               //car 4
                               new BuildingBuildingMaterial { BuildingID=92, BuildingMaterialID=95, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=92, BuildingMaterialID=96, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=92, BuildingMaterialID=97, MaterialPieces=4},
                               new BuildingBuildingMaterial { BuildingID=92, BuildingMaterialID=98, MaterialPieces=4},
                                               //car 5
                               new BuildingBuildingMaterial { BuildingID=93, BuildingMaterialID=95, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=93, BuildingMaterialID=96, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=93, BuildingMaterialID=97, MaterialPieces=5},
                               new BuildingBuildingMaterial { BuildingID=93, BuildingMaterialID=98, MaterialPieces=5},

                        };

            buildingbuildingmaterials.ForEach(s => context.BuildingBuildingMaterials.Add(s));
            context.SaveChanges();

            var weapon = new Weapon { ItemID = 59, ItemName = "Shovel", ItemMaxDurability = 999, WeaponDamage = 1, ItemPicture = "/Content/Pictures/BuyableWeapons/Shovel.png", IsRanged = false };
            context.Weapons.Add(weapon);
            context.SaveChanges();


            var buyableWeapons = new List<BuyableWeapon> {
                new BuyableWeapon {ItemID=60, ItemName="Katana", ItemMaxDurability=999,Cost=300, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Katana.png", IsRanged=false },
                new BuyableWeapon {ItemID=61, ItemName="Shotgun", ItemMaxDurability=10, Cost=200, WeaponDamage=1, ItemPicture="/Content/Pictures/BuyableWeapons/Shotgun.png", IsRanged= true},
                new BuyableWeapon {ItemID=62, ItemName="Hunting riffle", ItemMaxDurability=10, Cost=800, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/HuntingRiffle.png", IsRanged=true},
                new BuyableWeapon {ItemID=63, ItemName="Assault riffle", ItemMaxDurability=100,  Cost=7000, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/AssaultRiffle.png", IsRanged=true },
                new BuyableWeapon {ItemID=64, ItemName="Mini-gun", ItemMaxDurability=20, Cost=5000, WeaponDamage=4, ItemPicture="/Content/Pictures/BuyableWeapons/MiniGun.png", IsRanged = true},
                new BuyableWeapon {ItemID=65, ItemName="Chin a lake", ItemMaxDurability=2,  Cost=8000, WeaponDamage=10, ItemPicture="/Content/Pictures/BuyableWeapons/ChinALake.png", IsRanged= false},
                new BuyableWeapon {ItemID=66, ItemName="Bazooka", ItemMaxDurability=1, Cost=500, WeaponDamage=1, ItemPicture="/Content/Pictures/BuyableWeapons/Bazooka.png", IsRanged= true},
                new BuyableWeapon {ItemID=67, ItemName="Chainsaw", ItemMaxDurability=10, Cost=100, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/Chainsaw.png", IsRanged = false},
                new BuyableWeapon {ItemID=68, ItemName="Ray gun", ItemMaxDurability=1, Cost=2, WeaponDamage=2, ItemPicture="/Content/Pictures/BuyableWeapons/RayGun.png", IsRanged = true},

            };
            buyableWeapons.ForEach(s => context.BuyableWeapons.Add(s));
            context.SaveChanges();

            var craftableWeapons = new List<CraftableWeapon>
            {
                new CraftableWeapon {ItemID=69, ItemName = "Fire Mitts", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/FireMitts.png", IsRanged=false ,
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
                    new CraftableWeapon {ItemID=70, ItemName = "Flamethrower",  WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/Flamethrower.png", IsRanged=true,
                        CraftableWeaponMaterials = new List<CraftableWeaponMaterial> {
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=34, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=35, MaterialPieces=1 },
                             new CraftableWeaponMaterial { WeaponID=70, MaterialID=3, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=4, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=5, MaterialPieces=1 },
                            new CraftableWeaponMaterial { WeaponID=70, MaterialID=6, MaterialPieces=1 },

                        }
                    },
                    new CraftableWeapon {ItemID=71, ItemName = "Electric Rake", WeaponDamage = 2, ItemMaxDurability=2, ItemPicture= "/Content/Pictures/CraftableWeapons/ElectricRake.png", IsRanged=false ,
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
                            new Energy {ItemID=80, PlusEnergy = 6, ItemName = "Medium energy pack", ItemMaxDurability=1, Cost=5,ItemPicture = "/Content/Pictures/EnergyPacks/MediumEnergyPack.png" },
                            new Energy {ItemID=81, PlusEnergy = 16, ItemName = "Big energy pack", ItemMaxDurability=1, Cost=10, ItemPicture = "/Content/Pictures/EnergyPacks/BigEnergyPack.png" },
                        };

            energies.ForEach(s => context.Energies.Add(s));
            context.SaveChanges();


            var zombies = new List<Zombie> {
                //Base
                            new Zombie {ZombieID=1, ZombieName="Basic", ZombiePlaceAppear="Base", ZombieLife=1, ZombieRank=1, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/BasicZombie.png"},
                            new Zombie {ZombieID=2, ZombieName="Buckethead", ZombiePlaceAppear="Base", ZombieLife=1, ZombieRank=5, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/BucketheadZombie.png"},
                            new Zombie {ZombieID=3, ZombieName="Conehead", ZombiePlaceAppear="Base", ZombieLife=1, ZombieRank=3, ZombieDamage=1, RewardCoins=2, RewardXP=1, ZombiePicture="/Content/Pictures/Zombies/ConeheadZombie.png"},
                            new Zombie {ZombieID=4, ZombieName="Flag", ZombiePlaceAppear="Base", ZombieLife=2, ZombieRank=3, ZombieDamage=2, RewardCoins=5, RewardXP=3, ZombiePicture="/Content/Pictures/Zombies/FlagZombie.png"},
                            new Zombie {ZombieID=5, ZombieName="Vase gargantuar", ZombiePlaceAppear="Base", ZombieLife=5, ZombieRank=10, ZombieDamage=2, RewardCoins=5, RewardXP=3, ZombiePicture="/Content/Pictures/Zombies/VaseGargantuar.png"},

                //Desert
                            new Zombie {ZombieID=6, ZombieName="Buckethead", ZombiePlaceAppear="Desert", ZombieLife=1, ZombieRank=1, ZombieDamage=2, RewardCoins=5, RewardXP=4, ZombiePicture="/Content/Pictures/Zombies/BucketheadMummy.png"},
                            new Zombie {ZombieID=7, ZombieName="Camel", ZombiePlaceAppear="Desert", ZombieLife=1, ZombieRank=6, ZombieDamage=2, RewardCoins=6, RewardXP=6, ZombiePicture="/Content/Pictures/Zombies/CamelZombies.png"},
                            new Zombie {ZombieID=8, ZombieName="Conehead", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=2, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ConeheadMummy.png"},
                            new Zombie {ZombieID=9, ZombieName="Egypt rally", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=5, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/EgyptRallyZombie.png"},
                            new Zombie {ZombieID=10, ZombieName="Explorer", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=9, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ExplorerZombie.png"},
                            new Zombie {ZombieID=11, ZombieName="Flag", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=1, ZombieDamage=2, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/FlagMummyZombie.png"},
                            new Zombie {ZombieID=12, ZombieName="Imp", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=8, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/ImpMummy.png"},
                            new Zombie {ZombieID=13, ZombieName="Mummified gargantuar", ZombiePlaceAppear="Desert", ZombieLife=10, ZombieRank=10, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/MummifiedGargantuar.png"},
                            new Zombie {ZombieID=14, ZombieName="Mummy", ZombiePlaceAppear="Desert", ZombieLife=8, ZombieRank=1, ZombieDamage=1, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/MummyZombie.png"},
                            new Zombie {ZombieID=15, ZombieName="Pharoh", ZombiePlaceAppear="Desert", ZombieLife=8, ZombieRank=9, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/PharaohZombie.png"},
                            new Zombie {ZombieID=16, ZombieName="Pyramid-head", ZombiePlaceAppear="Desert", ZombieLife=4, ZombieRank=8, ZombieDamage=3, RewardCoins=8, RewardXP=10, ZombiePicture="/Content/Pictures/Zombies/PyramidHeadZombie.png"},
                            new Zombie {ZombieID=17, ZombieName="Ra", ZombiePlaceAppear="Desert", ZombieLife=9, ZombieRank=1, ZombieDamage=2, RewardCoins=15, RewardXP=18, ZombiePicture="/Content/Pictures/Zombies/RaZombie.png"},
                            new Zombie {ZombieID=18, ZombieName="Torchlight", ZombiePlaceAppear="Desert", ZombieLife=8, ZombieRank=3, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/TorchlightZombie.png"},
                            new Zombie {ZombieID=19, ZombieName="Zombot sphinxinator", ZombiePlaceAppear="Desert", ZombieLife=20, ZombieRank=10, ZombieDamage=3, RewardCoins=20, RewardXP=20, ZombiePicture="/Content/Pictures/Zombies/ZombotSphinxinator.png"},

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



            var adventures = new List<Adventure> {
                 new Adventure { AdventureName="1", AdventureType="Base", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=3,  AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=3,},
                 new Adventure { AdventureName="2", AdventureType="Base", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=3, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4},
                 new Adventure { AdventureName="3", AdventureType="Base", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=3,  AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5},
                 new Adventure { AdventureName="4. ", AdventureType="Base", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=3, AdventureMaxZombiesPerRound=4, AdventureRequerdEnergy=3},
                 new Adventure { AdventureName="5. ", AdventureType="Base", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=4,  AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4},
                 new Adventure { AdventureName="6. ", AdventureType="Base", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=4, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5},
                 new Adventure { AdventureName="7. ", AdventureType="Base", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=4, AdventureMaxZombiesPerRound=4, AdventureRequerdEnergy=3},
                 new Adventure { AdventureName="8. ", AdventureType="Base", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=4, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4},
                 new Adventure { AdventureName="9. ", AdventureType="Base", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=4,  AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5},
                 new Adventure { AdventureName="10. ", AdventureType="Base", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=1, AdventureMaxZombiesPerRound=1, AdventureRequerdEnergy=3},
                 new Adventure { AdventureName="11. ", AdventureType="Desert", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=4, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4},
                 new Adventure { AdventureName="12. ", AdventureType="Desert", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5},
                 new Adventure { AdventureName="13. ", AdventureType="Desert", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5},
                 new Adventure { AdventureName="14. ", AdventureType="Desert", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=3, AdventureMaxZombiesPerRound=4, AdventureRequerdEnergy=3},
                 new Adventure { AdventureName="15. ", AdventureType="Desert", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=4, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4},
                 new Adventure { AdventureName="16. ", AdventureType="Desert", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5},
                 new Adventure { AdventureName="17. ", AdventureType="Desert", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7,  AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5},
                 new Adventure { AdventureName="18. ", AdventureType="Desert", AdventureWaitingTime=10, AdventureXPBonus=6, AdventureSteps=3, AdventureMaxZombiesPerRound=4, AdventureRequerdEnergy=3},
                 new Adventure { AdventureName="19. ", AdventureType="Desert", AdventureWaitingTime=15, AdventureXPBonus=10, AdventureSteps=4, AdventureMaxZombiesPerRound=3, AdventureRequerdEnergy=4},
                 new Adventure { AdventureName="20. ", AdventureType="Desert", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5},
                 new Adventure { AdventureName="21. ", AdventureType="Pirate", AdventureWaitingTime=25, AdventureXPBonus=30, AdventureSteps=7, AdventureMaxZombiesPerRound=2, AdventureRequerdEnergy=5}

            };
            adventures.ForEach(s => context.Adventures.Add(s));
            context.SaveChanges();



            var adventureDrops = new List<AdventureDrop> {
                new AdventureDrop { AdventureID=1, DropableItemID=94, ItemDroprate= 0.5, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=1, DropableItemID=54, ItemDroprate= 0.3, ItemMaxDrop=3 },

                new AdventureDrop { AdventureID=2, DropableItemID=94, ItemDroprate= 0.75, ItemMaxDrop=2 },
                new AdventureDrop { AdventureID=2, DropableItemID=54, ItemDroprate= 0.5, ItemMaxDrop=3 },


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



            var storyMissions = new List<StoryMission> {
                        new StoryMission { MissionID = 1, MissionName="Rebuild Your House I", RequiredLevel=1, RewardXP=100, RewardICoins=100, IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 1, MissionID = 1, ItemID = 94, ItemPieces = 2, TaskText="Collect 2 bricks!"},
                        new CollectMissionTask { MissionTaskID = 2, MissionID = 1, ItemID = 2, ItemPieces = 1, TaskText="Build level 1 house!"}
                    } },


                new StoryMission { MissionID = 2, MissionName="Rebuild Your House II", RequiredLevel=3, RewardXP=150, RewardICoins=150, IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 3, MissionID = 2, ItemID = 58, ItemPieces = 2, TaskText="Collect 2 screws!"},
                        new CollectMissionTask { MissionTaskID = 4, MissionID = 2, ItemID = 55, ItemPieces = 2, TaskText="Collect 2 boards!"},
                        new CollectMissionTask { MissionTaskID = 5, MissionID = 2, ItemID = 57, ItemPieces = 3, TaskText="Collect 3 roof tiles!"},
                        new CollectMissionTask { MissionTaskID = 6, MissionID = 2, ItemID = 56, ItemPieces = 3, TaskText="Collect 3 metal sheds!"},
                    } },


               new StoryMission { MissionID = 3, MissionName="Rebuild Your House III", RequiredLevel=5, RewardXP=200, RewardICoins=200, IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 7, MissionID = 3, ItemID = 54, ItemPieces = 2, TaskText="Collect 2 blueprints!"},
                    } },

               new StoryMission { MissionID = 4, MissionName="Rebuild Your House IV", RequiredLevel=5, RewardXP=200, RewardICoins=200,  IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 8, MissionID = 4, ItemID = 54, ItemPieces = 6, TaskText="Collect 6 blueprints!"},
                        new RepairMissionTask { MissionTaskID = 9, MissionID = 4, ItemID = 2, ItemPieces = 3, TaskText="Repair the house 3 times!"}
                    } },

               new StoryMission { MissionID = 5, MissionName="Tools for Success I", RequiredLevel=7, RewardXP=250, RewardICoins=250, IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 10, MissionID = 5, ItemID = 20, ItemPieces = 1, TaskText="Build level 1 toolshed!"},
                        new CollectMissionTask { MissionTaskID = 11, MissionID = 5, ItemID = 94, ItemPieces = 80, TaskText="Collect 80 bricks!"}
                    } },

               new StoryMission { MissionID = 6, MissionName="Tools for Success II", RequiredLevel=7,  RewardXP=300, RewardICoins=200,  IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 12, MissionID = 6, ItemID = 99, ItemPieces = 4, TaskText="Collect 4 fertilizer!"},
                        new CollectMissionTask { MissionTaskID = 13, MissionID = 6, ItemID = 100, ItemPieces = 3, TaskText="Collect 3 metal buckets!"},
                        new CollectMissionTask { MissionTaskID = 14, MissionID = 6, ItemID = 52, ItemPieces = 2, TaskText="Collect 2 rakes!"},
                    } },

               new StoryMission { MissionID = 7, MissionName="Tools for Success III", RequiredLevel=7, RewardXP=150, RewardICoins=150,  IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new RepairMissionTask { MissionTaskID = 15, MissionID = 7, ItemID = 20, ItemPieces = 6, TaskText="Complete the toolshed!"}, //!!!!!!!!!!!!!!!
                        new CollectMissionTask { MissionTaskID = 16, MissionID = 7, ItemID = 36, ItemPieces = 50, TaskText="Collect 50 duct tapes!"}
                    } },

               new StoryMission { MissionID = 8, MissionName="Build Garden shed I", RequiredLevel=7, RewardXP=150, RewardICoins=150,  IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new HarvestMissionTask { MissionTaskID = 17, MissionID = 8, ItemID = 26, ItemPieces = 2, TaskText="Harvest 2 peppers!"},
                        new HarvestMissionTask { MissionTaskID = 18, MissionID = 8, ItemID = 27, ItemPieces = 2, TaskText="Harvest 2 potatoes!"}
                    } },

               new StoryMission { MissionID = 9, MissionName="Build Garden shed II", RequiredLevel=7, RewardXP=150, RewardICoins=150,  IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 19, MissionID = 9, ItemID = 47, ItemPieces = 6, TaskText="Get 6 garden trimmer!"},
                        new HarvestMissionTask { MissionTaskID = 20, MissionID = 9, ItemID = 29, ItemPieces = 5, TaskText="Harwest 5 strwberries!"}
                    } },

               new StoryMission { MissionID = 10, MissionName="Dude where is my car? I", RequiredLevel=7, RewardXP=150, RewardICoins=150,  IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 21, MissionID = 10, ItemID = 89, ItemPieces = 1, TaskText="Buy 1 old car!"},
                        new RepairMissionTask { MissionTaskID = 22, MissionID = 10, ItemID = 89, ItemPieces = 50, TaskText="Fix old car 10 times!"}
                    } },

               new StoryMission { MissionID = 11, MissionName="Dude where is my car? II", RequiredLevel=7, RewardXP=150, RewardICoins=150,  IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new KillingMissionTask { MissionTaskID = 23, MissionID = 11, ItemPieces = 20, TaskText="Kill 20 zombies!"}, //!!!!!!!
                        new CollectMissionTask { MissionTaskID = 24, MissionID = 11, ItemID = 38, ItemPieces = 5, TaskText="Get 5 motor oil!"},
                        new CollectMissionTask { MissionTaskID = 25, MissionID = 11, ItemID = 51, ItemPieces = 5, TaskText="Find 5 batteries"}
                    } },

              new StoryMission { MissionID = 12, MissionName="Dude where is my car? III", RequiredLevel=7, RewardXP=150, RewardICoins=150,  IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new KillingMissionTask { MissionTaskID = 26, MissionID = 12, ItemID = 1, ItemPieces = 20, TaskText="Kill 20 zombies!"}, //!!!!!!!
                        new CollectMissionTask { MissionTaskID = 27, MissionID = 12, ItemID = 38, ItemPieces = 5, TaskText="Get 5 motor oil!"}  /////////////
                    } },

              new StoryMission { MissionID = 13, MissionName="Dude where is my car? IV", RequiredLevel=7, RewardXP=150, RewardICoins=150,  IsNextMission=true, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 28, MissionID = 13, ItemID = 35, ItemPieces = 8, TaskText="Get 8 gasoline cans!"},
                        new CollectMissionTask { MissionTaskID = 29, MissionID = 13, ItemID = 62, ItemPieces = 5, TaskText="Buy 5 hunting rifles!"}
                    } },

              new StoryMission { MissionID = 14, MissionName="Dude where is my car? V", RequiredLevel=7, RewardXP=150, RewardICoins=150,  IsNextMission=false, MissionTasks =  new List<MissionTask>{
                        new CollectMissionTask { MissionTaskID = 30, MissionID = 14, ItemID = 95, ItemPieces = 15, TaskText="Get 15 car waxes!"},
                        new CollectMissionTask { MissionTaskID = 31, MissionID = 14, ItemID = 96, ItemPieces = 15, TaskText="Get 15 spare parts!"},
                        new CollectMissionTask { MissionTaskID = 32, MissionID = 14, ItemID = 97, ItemPieces = 15, TaskText="Get 15 spark plugs!"},
                        new CollectMissionTask { MissionTaskID = 33, MissionID = 14, ItemID = 98, ItemPieces = 15, TaskText="Get 15 jumper cables!" }
                    } },

        };
            storyMissions.ForEach(s => context.Missions.Add(s));
            context.SaveChanges();




            var sideMissions = new List<SideMission> {

                    new SideMission { MissionID = 15, MissionName="Who's the Boss I", RewardXP=150, RewardICoins=150,  RequiredLevel=1, IsNextMission=true,
                        MissionTasks =  new List<MissionTask>{
                            new KillingMissionTask { MissionTaskID = 34, MissionID = 15, ItemID = 1 , ItemPieces = 5, TaskText="Kill 5 basic zombie!"},
                        } },


                    new SideMission { MissionID = 16, MissionName="Who's the Boss II",RewardXP=150, RewardICoins=150, RequiredLevel=3, IsNextMission=true, MissionTasks =  new List<MissionTask>{
                            new KillingMissionTask { MissionTaskID = 35, MissionID = 16, ItemID = 1, ItemPieces = 2, TaskText="Kill 3 basic zombies!"},
                            new KillingMissionTask { MissionTaskID = 36, MissionID = 16, ItemID = 2, ItemPieces = 2, TaskText="Kill 7 buckethead zombies!"},
                        } },


                   new SideMission { MissionID = 17, MissionName="Who's the Boss III", RewardXP=150, RewardICoins=150, RequiredLevel=5, IsNextMission=true, MissionTasks =  new List<MissionTask>{
                            new KillingMissionTask { MissionTaskID = 37, MissionID = 17, ItemID = 2, ItemPieces = 2, TaskText="Kill 10 buckethead zombies!"},
                        } },

                   new SideMission { MissionID = 18, MissionName="Who's the Boss IV", RewardXP=150, RewardICoins=150, RequiredLevel=7, IsNextMission=true, MissionTasks =  new List<MissionTask>{
                            new KillingMissionTask { MissionTaskID = 38, MissionID = 18, ItemID = 2, ItemPieces = 15, TaskText="Kill 15 buckethead zombies!"},
                            new KillingMissionTask { MissionTaskID = 39, MissionID = 18, ItemID = 1, ItemPieces = 20, TaskText="Kill 20 basic zombies!"}
                        } },

                   new SideMission { MissionID = 19, MissionName="Who's the Boss V", RewardXP=150, RewardICoins=150, RequiredLevel=7, IsNextMission=false, MissionTasks =  new List<MissionTask>{
                            new KillingMissionTask { MissionTaskID = 40, MissionID = 5, ItemID = 1, ItemPieces = 30, TaskText="Kill 30 basic zombies!"},
                            new KillingMissionTask { MissionTaskID = 41, MissionID = 5, ItemID = 3, ItemPieces = 10, TaskText="Kill 10 zonehead zombies!"}
                        } },


                    new SideMission { MissionID = 20, MissionName="Winter is coming I", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=true,
                        MissionTasks =  new List<MissionTask>{
                            new HarvestMissionTask { MissionTaskID = 42, MissionID = 20, ItemID = 25 , ItemPieces = 10, TaskText="Harvest 10 melons!"},
                            new HarvestMissionTask { MissionTaskID = 43, MissionID = 20, ItemID = 26 , ItemPieces = 5, TaskText="Harvest 5 peppers!"},
                        } },


                    new SideMission { MissionID = 21, MissionName="Winter is coming II", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=true,
                        MissionTasks =  new List<MissionTask>{
                            new HarvestMissionTask { MissionTaskID = 44, MissionID = 21, ItemID = 27 , ItemPieces = 25, TaskText="Harvest 25 potatoes!"},
                            new HarvestMissionTask { MissionTaskID = 45, MissionID = 21, ItemID = 26 , ItemPieces = 50, TaskText="Harvest 50 peppers!"},
                        } },

                    new SideMission { MissionID = 22, MissionName="Winter is coming III", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=false,
                        MissionTasks =  new List<MissionTask>{
                            new HarvestMissionTask { MissionTaskID = 46, MissionID = 22, ItemID = 29 , ItemPieces = 30, TaskText="Harvest 30 strawberries!"},
                        } },

            };

            sideMissions.ForEach(s => context.Missions.Add(s));
            context.SaveChanges();



            var dailyMissions = new List<DailyMission> {

                    new DailyMission { MissionID = 23, MissionName="Daily collect mission I", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=false,  MissionTasks =  new List<MissionTask>{
                            new CollectMissionTask { MissionTaskID = 47, MissionID = 23, ItemID = 55 , ItemPieces = 5, TaskText="Get 5 pieces of boards!"},
                        } },

                    new DailyMission { MissionID = 24, MissionName="Daily collect mission II", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=false,  MissionTasks =  new List<MissionTask>{
                            new CollectMissionTask { MissionTaskID = 48, MissionID = 24, ItemID = 55 , ItemPieces = 4, TaskText="Get 4 pieces of boards!"},
                        } },

                    new DailyMission { MissionID = 25, MissionName="Daily collect mission III", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=false,  MissionTasks =  new List<MissionTask>{
                            new CollectMissionTask { MissionTaskID = 49, MissionID = 25, ItemID = 56 , ItemPieces = 4, TaskText="Get 4 pieces of!"},
                        } },

                    new DailyMission { MissionID = 26, MissionName="Daily collect mission IV", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=false,  MissionTasks =  new List<MissionTask>{
                            new CollectMissionTask { MissionTaskID = 50, MissionID = 26, ItemID = 57 , ItemPieces = 4, TaskText="Get 4 pieces of!"},
                        } },

                    new DailyMission { MissionID = 27, MissionName="Daily AdventureMission I", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=false,  MissionTasks =  new List<MissionTask>{
                            new AdventureMissionTask { MissionTaskID = 51, MissionID = 27, ItemID = 0 , ItemPieces = 2, TaskText="Complete 2 adventures"},
                        } },

                    new DailyMission { MissionID = 28, MissionName="Daily HarvestMission I", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=false,  MissionTasks =  new List<MissionTask>{
                            new HarvestMissionTask { MissionTaskID = 52, MissionID = 28, ItemID = 0 , ItemPieces = 2, TaskText="Harvest 2 fields!"},
                        } },

                    new DailyMission { MissionID = 29, MissionName="Daily killing mission I", RewardXP=150, RewardICoins=150, RequiredLevel=1, IsNextMission=false,  MissionTasks =  new List<MissionTask>{
                            new KillingMissionTask { MissionTaskID = 53, MissionID = 29, ItemID = 0 , ItemPieces = 2, TaskText="Kill 2 zombies"},
                        } },

                };

            dailyMissions.ForEach(s => context.DailyMissions.Add(s));
            context.SaveChanges();


        }
    }
}
