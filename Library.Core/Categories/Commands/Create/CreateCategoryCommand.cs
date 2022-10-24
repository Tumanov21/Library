using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Create
{
    public class CreateCategoryCommand
    {
        public class Request : IRequest<Response>
        {
            public AddCategoryDto AddCategoryDto { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }
        }
    }
}
