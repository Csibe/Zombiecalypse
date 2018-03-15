using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Configure Student & StudentAddress entity
            modelBuilder.Entity<User>()
                        .HasOptional(s => s.Character) // Mark Character property optional in User entity
                        .WithRequired(ad => ad.User); // mark User property as required in Character entity. Cannot save Character without User


            modelBuilder.Entity<Inventory>()
            .HasRequired<Item>(s => s.Item)
            .WithMany(g => g.Inventories)
            .HasForeignKey<int>(s => s.ItemID);

       /*     modelBuilder.Entity<Item>()
        .Map(u => u.Requires("InheritedType").HasValue(1))
        .Map<Building>(f => f.Requires("InheritedType").HasValue(2))
        .Map<BuildingMaterial>(f => f.Requires("InheritedType").HasValue(3))
        .Map<BuildingBuildingMaterial>(f => f.Requires("InheritedType").HasValue(4));
        */
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<RegistrationViewModel> RegistrationViewModels { get; set; }
        public DbSet<BuildingMaterial> BuildingMaterials { get; set; }
        public DbSet<BuildingBuildingMaterial> BuildingBuildingMaterials { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<WebApplication1.Models.FileUploader> FileUploaders { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.ViewModels.CharacterViewModel> CharacterViewModels { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Level> Levels { get; set; }
    }

}