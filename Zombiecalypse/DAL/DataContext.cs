using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Security;
using Zombiecalypse.Models;


namespace Zombiecalypse.DAL
{

    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<BuildingBuildingMaterial> BuildingBuildingMaterials { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Zombie> Zombies { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ZombieDrop> ZombieDrops { get; set; }
        public DbSet<AdventureDrop> AdventureDrops { get; set; }
        public DbSet<ZombieAttackBase> ZombieAttackBases { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<CraftableWeapon> CraftableWeapons { get; set; }
        public DbSet<BuyableWeapon> BuyableWeapons { get; set; }
        public DbSet<CraftableWeaponMaterial> CraftableWeaponsMaterials { get; set; }
        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<ZombieAttackAdventurer> ZombieAttackAdventurers { get;set; }

        public DbSet<BuildingDetails> BuildingDetails { get; set; }
        public DbSet<PlantField> PlantFields { get; set; }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Energy> Energies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            /* modelBuilder.Entity<BuildingBuildingMaterial>().ToTable("BuildingBuildingMaterials");
             modelBuilder.Entity<CraftableWeaponMaterial>().ToTable("CraftableWeaponMaterials");
             */
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

            /*    modelBuilder.Entity<Inventory>()
                .HasRequired<Item>(s => s.Item)
                .WithMany(g => g.Inventories)
                .HasForeignKey<int>(s => s.ItemID);*/

            /*     modelBuilder.Entity<Item>()
             .Map(u => u.Requires("InheritedType").HasValue(1))
             .Map<Building>(f => f.Requires("InheritedType").HasValue(2))
             .Map<BuildingMaterial>(f => f.Requires("InheritedType").HasValue(3))
             .Map<BuildingBuildingMaterial>(f => f.Requires("InheritedType").HasValue(4));
             */

            base.OnModelCreating(modelBuilder);
        }
    }
}
