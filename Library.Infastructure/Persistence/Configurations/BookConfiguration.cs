using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(new Book()
            {
                Id = 1,
                Title = "Book",
            });
            builder.HasKey(x => x.Id);

            builder
                .HasMany(c => c.Categories)
                .WithMany(c => c.Books)
                .UsingEntity<BooksCategories>(
                 book => book
                     .HasOne(ba => ba.Category)
                     .WithMany(b => b.BooksCategories)
                     .HasForeignKey(bc => bc.CategoryId),
                 category => category
                     .HasOne(ca => ca.Book)
                     .WithMany(c => c.BooksCategories)
                     .HasForeignKey(cb => cb.BookId)
                 );
        }
    }
}
