using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Wardrobe> Wardrobes { get; set; }
        public DbSet<Outfit> Outfits { get; set; }
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<OutfitClothingItem> OutfitClothingItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Wardrobe>()
                .HasMany(w => w.ClothingItems)
                .WithOne(ci => ci.Wardrobe)
                .HasForeignKey(ci => ci.WardrobeId);

            modelBuilder.Entity<Wardrobe>()
                .HasMany(w => w.Outfits)
                .WithOne(o => o.Wardrobe)
                .HasForeignKey(o => o.WardrobeId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Wardrobe)
                .WithOne(w => w.User)
                .HasForeignKey<Wardrobe>(w => w.UserId)
                .IsRequired();

            modelBuilder.Entity<OutfitClothingItem>()
                .HasKey(oci => new { oci.OutfitId, oci.ClothingItemId });

            modelBuilder.Entity<OutfitClothingItem>()
                .HasOne(oci => oci.Outfit)
                .WithMany(o => o.OutfitClothingItems)
                .HasForeignKey(oci => oci.OutfitId);

            modelBuilder.Entity<OutfitClothingItem>()
                .HasOne(oci => oci.ClothingItem)
                .WithMany(ci => ci.OutfitClothingItems)
                .HasForeignKey(oci => oci.ClothingItemId);
        }


    }



}