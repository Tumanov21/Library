using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dto.BookDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Queries.GetById
{
    public class GetByIdBookQuery
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }
        public class Response
        {
            public GetBookDto Book { get; set; }
        }
    }
}
