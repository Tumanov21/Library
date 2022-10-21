using Library.Core.Categories.Commands.Create;
using Library.Core.Categories.Commands.Remove;
using Library.Core.Categories.Commands.Update;
using Library.Core.Categories.Queries.GetAll;
using Library.Core.Categories.Queries.GetById;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllCategory")]
        public async Task<GetAllCategoryQuery.Response> GetAllCategory()
            => await _mediator.Send(new GetAllCategoryQuery.Request());

        [HttpGet("GetById")]
        public async Task<GetByIdCategoryQuery.Response> GetById(int id)
            => await _mediator.Send(new GetByIdCategoryQuery.Request { Id = id });

        [HttpPost("Add")]
        public async Task<Unit> Add(AddCategoryDto categoryDto)
            => await _mediator.Send(new CreateCategoryCommand(categoryDto));

        [HttpPost("Update")]
        public async Task<Unit> Update(UpdateCategoryDto categoryDto)
            => await _mediator.Send(new UpdateCategoryCommand(categoryDto));

        [HttpPost("Remove")]
        public async Task<Unit> Delte(int id)
            => await _mediator.Send(new RemoveCategoryCommand(id));
    }
}
