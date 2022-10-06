using Library.Domain.Entities;
using Library.Infastructure.Persistence.Repositories.Query.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Queries.GetById
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery.Request, GetByIdCategoryQuery.Response>
    {
        private readonly ICategoryRepositoryQuery _categoryRepositoryQuery;

        public GetByIdCategoryQueryHandler(ICategoryRepositoryQuery categoryRepositoryQuery)
        {
            _categoryRepositoryQuery = categoryRepositoryQuery;
        }

        public async Task<GetByIdCategoryQuery.Response> Handle(GetByIdCategoryQuery.Request request, CancellationToken cancellationToken)
            => new GetByIdCategoryQuery.Response()
            {
                Category = await _categoryRepositoryQuery.GetById(request.Id)
            };
    }
}
