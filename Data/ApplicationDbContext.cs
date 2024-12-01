using Company.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Company.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API for the relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Department) // Each User has one Department
                .WithMany(d => d.Users)    // Each Department has many Users
                .HasForeignKey(u => u.DepartmentId) // Foreign Key
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete

            base.OnModelCreating(modelBuilder);
        }

    }
}
