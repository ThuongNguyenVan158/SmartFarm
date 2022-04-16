using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using SmartFarm.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SmartFarm.Data
{
    public class AppDbContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new FarmConfiguration());
            modelBuilder.ApplyConfiguration(new InputConfiguration());
            modelBuilder.ApplyConfiguration(new OutputConfiguration());
            modelBuilder.ApplyConfiguration(new StatisticalConfiguration());
            modelBuilder.ApplyConfiguration(new InputOutputConfiguration());
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Farm> Farm { get; set; }
        public DbSet<Input> Input { get; set; }
        public DbSet<Output> Output { get; set; }
        public DbSet<InputOutput> InputOutput { get; set; }
        public DbSet<Statistical> Statistical { get; set; }
    }
}
