using Library.Core.Categories.Queries.GetAll;
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
    }
}
