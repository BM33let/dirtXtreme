using BOROMOTORS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BOROMOTORS.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Replace this with your actual database connection string
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
                    b => b.MigrationsAssembly("BOROMOTORS"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships, keys, and constraints

            // Configure the Order table relationship with DirtBike
            modelBuilder.Entity<Order>()
                .HasOne(o => o.DirtBike)  // An order is associated with one dirt bike
                .WithMany()  // A dirt bike can be part of many orders
                .HasForeignKey(o => o.DirtBikeId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete if the dirt bike is deleted

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)  // An order is associated with one customer
                .WithMany()  // A customer can have many orders
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete if the customer is deleted

            // Configure the DirtBike entity with unique constraints on model name
            modelBuilder.Entity<DirtBike>()
                .HasIndex(d => d.Model)
                .IsUnique();  // Ensure that the dirt bike model name is unique

            // Set up additional configurations if needed
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();  // Ensure emails are unique in the Customers table
        }

        // DbSets representing the entities
        public DbSet<DirtBike> DirtBikes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
