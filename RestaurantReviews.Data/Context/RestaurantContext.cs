using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Models;

namespace RestaurantReviews.Data.Context {
    public class RestaurantContext : DbContext {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "Data Source=.\\SQLEXPRESS;Initial Catalog=RestaurantReviews-2023Spring;Trusted_Connection=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuisine>().HasKey(p => p.CuisineCode);
            modelBuilder.Entity<Cuisine>().Property(p => p.CuisineCode).HasMaxLength(20);

            modelBuilder.Entity<Restaurant>(entity => {
                entity.Property(e => e.CuisineCode).HasMaxLength(20);
                entity.HasOne(d => d.Cuisine)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.CuisineCode)
                    .HasConstraintName("FK_Restaurants_Cuisines");
            });


            modelBuilder.Entity<Cuisine>().HasData(new List<Cuisine>()
            {
                new Cuisine() { CuisineCode="Chinese", DisplayName = "Chinese", Description = "Chinese"},
                new Cuisine() { CuisineCode="Pizza", DisplayName = "Pizza", Description = "Pizza"},
                new Cuisine() { CuisineCode="Healthy", DisplayName = "Healthy", Description = "Healthy"},
                new Cuisine() { CuisineCode="Mexican", DisplayName = "Mexican", Description = "Mexican"},
                new Cuisine() { CuisineCode="Indian", DisplayName = "Indian", Description = "Indian Food"},
                new Cuisine() { CuisineCode="Italian", DisplayName = "Italian", Description = "Italian Food"},
                new Cuisine() { CuisineCode="French", DisplayName = "French", Description = "French"},
                new Cuisine() { CuisineCode="Russian", DisplayName = "Russian", Description = "Russian"},
                new Cuisine() { CuisineCode="American", DisplayName = "American", Description = "American"},
                new Cuisine() { CuisineCode="Ukrainian", DisplayName = "Ukrainian", Description = "Ukrainian"}
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
