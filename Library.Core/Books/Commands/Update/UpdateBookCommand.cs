using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Update
{
    public class UpdateBookCommand
    {
        public class Request : IRequest<Response>
        {
            public Book Book { get; set; }
        }

        public class Response
        {
            public Book Book { get; set; }
        }
    }
}
