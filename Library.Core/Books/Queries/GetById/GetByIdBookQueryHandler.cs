using Library.Infastructure.Persistence.Repositories.Query.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Queries.GetById
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery.Request, GetByIdBookQuery.Response>
    {
        private readonly IBookRepositoryQuery _bookRepositoryQuery;

        public GetByIdBookQueryHandler(IBookRepositoryQuery bookRepositoryQuery)
        {
            _bookRepositoryQuery = bookRepositoryQuery;
        }

        public async Task<GetByIdBookQuery.Response> Handle(GetByIdBookQuery.Request request, CancellationToken cancellationToken)
        {
            if (request.Id == 0 || request.Id < 0)
                return new GetByIdBookQuery.Response()
                {
                    Book = null
                };

            return new GetByIdBookQuery.Response()
            {
                Book = await _bookRepositoryQuery.GetById(request.Id)
            };
        }
    }
}
