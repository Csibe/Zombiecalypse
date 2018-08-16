
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


        }
    }
}