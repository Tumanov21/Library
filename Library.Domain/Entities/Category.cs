using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<Book>? Books { get; set; }
        public List<BooksCategories> BooksCategories { get; set; }
    }
}
