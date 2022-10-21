using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Queries.GetById
{
    public class GetByIdCategoryQuery
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }
        public class Response
        {
            public GetCategoryDto Category { get; set; }
        }
    }
}
