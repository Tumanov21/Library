using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Dtos.BookDtos
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
