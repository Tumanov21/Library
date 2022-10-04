using Library.Domain.Entities;
using Library.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
