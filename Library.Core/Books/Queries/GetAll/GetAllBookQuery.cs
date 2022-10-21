using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dto.BookDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Queries.GetAll
{
    public class GetAllBookQuery
    {
        public class Request : IRequest<Response>
        {

        }

        public class Response
        {
            public IReadOnlyCollection<GetBookDto> Books { get; set; }
        }
    }
}
