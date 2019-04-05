
using System.Data.Entity;
using Zombiecalypse.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zombiecalypse.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<BuildingMaterial> BuildingMaterials { get; set; }
        public DbSet<BuildingBuildingMaterial> BuildingBuildingMaterials { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<CraftableWeapon> CraftableWeapons { get; set; }
        public DbSet<CraftableWeaponMaterial> CraftableWeaponMaterials { get; set; }
        public DbSet<BuyableWeapon> BuyableWeapons { get; set; }
        public DbSet<Energy> Energies { get; set; }
        public DbSet<CharacterField> CharacterFields { get; set; }
        public DbSet<Zombie> Zombies { get; set; }
        public DbSet<ZombieDrop> ZombieDrops { get; set; }
        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<ZombieAttackAdventurer> ZombieAttackAdventurers { get; set; }
        public DbSet<ZombieAttackBase> ZombieAttackBases { get; set; }
        public DbSet<AdventureDrop> AdventureDrops { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<StoryMission> StoryMissions { get; set; }
        public DbSet<SideMission> SideMissions { get; set; }
        public DbSet<DailyMission> DailyMissions { get; set; }

        
        public DbSet<MissionTask> MissionTasks { get; set; }
        public DbSet<CollectMissionTask> CollectMissionTasks { get; set; }
        public DbSet<HarvestMissionTask> HarvestMissionTasks { get; set; }
        public DbSet<CharacterMissionTask> CharacterMissionTasks { get; set; }
        public DbSet<CharacterMission> CharacterMissions { get; set; }

        public DbSet<KillingMissionTask> KillingMissionTasks { get; set; }


        //public DbSet<RepairStoryMission> RepairStoryMissions { get; set; }
        //public DbSet<CollectableRepetableMission> CollectableRepetableMissions { get; set; }
        //public DbSet<HarvestRepetableMission> HarvestRepetableMissions { get; set; }
        //public DbSet<RepairRepetableMission> RepairRepetableMissions { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        public DbSet<OwnedDog> OwnedDogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Item>()
            .Property(p => p.ItemID)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Plant>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Plants");
            });

            modelBuilder.Entity<Building>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Buildings");
            });

            modelBuilder.Entity<Material>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Materials");
            });

            modelBuilder.Entity<BuildingMaterial>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("BuildingMaterials");
            });

            modelBuilder.Entity<Weapon>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Weapons");
            });

            modelBuilder.Entity<CraftableWeapon>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("CraftableWeapons");
            });

            modelBuilder.Entity<BuyableWeapon>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("BuyableWeapons");
            });

            modelBuilder.Entity<Field>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Field");
            });

            modelBuilder.Entity<Energy>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Energies");
            });

            modelBuilder.Entity<Mission>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Missions");
            });


            modelBuilder.Entity<Dog>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Dogs");
            });


        }
    }
}