using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Queries.GetAll
{
    public class GetAllCategoryQuery
    {
        public class Request : IRequest<Response>
        {
        }
        public class Response
        {
            public IReadOnlyCollection<GetCategoryDto> Categories { get; set; }
        }
    }
}
