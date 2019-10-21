using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SaraKhezriCrudTest.Models
{
    public class Dbctx : DbContext
    {
        public Dbctx(DbContextOptions<Dbctx> options)
             : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
                        .ToTable("Customers");

            modelBuilder.Entity<Customer>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Customer>()
                        .Property(x => x.FirstName);

            modelBuilder.Entity<Customer>()
                        .Property(x => x.LastName);

            modelBuilder.Entity<Customer>()
                        .Property(x => x.DateOfBirth);

            modelBuilder.Entity<Customer>()
                        .Property(x => x.PhoneNumber);

            modelBuilder.Entity<Customer>()
                        .Property(x => x.Email);

            modelBuilder.Entity<Customer>()
                        .Property(x => x.BankAccountNumber);


            base.OnModelCreating(modelBuilder);
        }
        public static Dbctx Create(DbContextOptions<Dbctx> options) =>
          new Dbctx(options);
    }
}
