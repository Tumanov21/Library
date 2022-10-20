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
    public class BooksCategoriesConfiguration : IEntityTypeConfiguration<BooksCategories>
    {
        public void Configure(EntityTypeBuilder<BooksCategories> builder)
        {
            builder.HasData(new BooksCategories()
            {
                CategoryId = 1,
                BookId = 1,
            });
        }
    }
}
