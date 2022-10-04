using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Data
{
    public class EFContext:DbContext
    {
        public EFContext(DbContextOptions<EFContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().HasKey(c => c.Id);

            modelBuilder.Entity<Book>()
                .HasMany(c => c.Categories)
                .WithMany(c => c.Books)
                .UsingEntity(x =>
                    {
                        x.ToTable("BooksCategories");
                    });
                    
        }
    }
}
