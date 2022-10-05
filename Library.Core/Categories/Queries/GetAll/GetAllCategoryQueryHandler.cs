using Library.Infastructure.Data.Repositories.Query.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Queries.GetAll
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery.Request, GetAllCategoryQuery.Response>
    {
        private readonly ICategoryRepositoryQuery _categoryRepositoryQuery;

        public GetAllCategoryQueryHandler(ICategoryRepositoryQuery categoryRepositoryQuery)
        {
            _categoryRepositoryQuery = categoryRepositoryQuery;
        }

        public async Task<GetAllCategoryQuery.Response> Handle(GetAllCategoryQuery.Request request, CancellationToken cancellationToken)
            => new GetAllCategoryQuery.Response()
            {
                Categories = await _categoryRepositoryQuery.GetAll()
            };
    }
}
