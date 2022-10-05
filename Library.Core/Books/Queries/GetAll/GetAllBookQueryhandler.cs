using Library.Infastructure.Data.Repositories.Query.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Queries.GetAll
{
    public class GetAllBookQueryhandler : IRequestHandler<GetAllBookQuery.Request, GetAllBookQuery.Response>
    {
        private readonly IBookRepositoryQuery _bookRepositoryQuery;

        public GetAllBookQueryhandler(IBookRepositoryQuery bookRepositoryQuery)
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
