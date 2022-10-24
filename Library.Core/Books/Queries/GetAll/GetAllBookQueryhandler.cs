using Library.Infastructure.Persistence.Repositories.Query.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Queries.GetAll
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery.Request, GetAllBookQuery.Response>
    {
        private readonly IBookRepositoryQuery _bookRepositoryQuery;

        public GetAllBookQueryHandler(IBookRepositoryQuery bookRepositoryQuery)
        {
            _bookRepositoryQuery = bookRepositoryQuery;
        }

        public async Task<GetAllBookQuery.Response> Handle(GetAllBookQuery.Request request, CancellationToken cancellationToken)
            => new GetAllBookQuery.Response()
            {
                Books = await _bookRepositoryQuery.GetAll()
            };
    }
}
