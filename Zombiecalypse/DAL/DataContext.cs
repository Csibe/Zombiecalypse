using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using Zombiecalypse.Models;
using Zombiecalypse.ViewModels;

namespace Zombiecalypse.DAL
{

    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationUser>()
        .HasOptional(f => f.Character)
        .WithRequired(s => s.ApplicationUser);

            // Configure Student & StudentAddress entity
            /*  modelBuilder.Entity<User>()
                          .HasOptional(s => s.Character) // Mark Character property optional in User entity
                          .WithRequired(ad => ad.User); // mark User property as required in Character entity. Cannot save Character without User

            */
            /*      modelBuilder.Entity<ApplicationUser>()
        .HasOptional(m => m.Character)
        .WithRequired(m => m.ApplicationUser)
        .Map(p => p.MapKey("UserId"));
        */
            /*   modelBuilder.Entity<Foo>()
               .HasOptional(f => f.Boo)
               .WithRequired(s => s.Foo);
               */

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
        public DbSet<Zombiecalypse.Models.FileUploader> FileUploaders { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<Zombiecalypse.ViewModels.CharacterViewModel> CharacterViewModels { get; set; }

        public System.Data.Entity.DbSet<Zombiecalypse.Models.Level> Levels { get; set; }

        public DbSet<Adventure> Adventures { get; set; }

    }

}