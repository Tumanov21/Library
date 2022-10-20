using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Create
{
    public class CreateBookCommand
    {
        public class Request : IRequest<Unit>
        {
            public Book Book { get; set; }
            public Category Category { get; set; }
        }
    }
}
