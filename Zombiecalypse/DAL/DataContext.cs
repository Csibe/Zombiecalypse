
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
        }
    }
}