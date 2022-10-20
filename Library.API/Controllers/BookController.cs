using Library.Core.Books.Commands.Create;
using Library.Core.Books.Commands.Remove;
using Library.Core.Books.Commands.Update;
using Library.Core.Books.Queries.GetAll;
using Library.Core.Books.Queries.GetById;
using Library.Domain.Entities;
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
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllBooks")]
        public async Task<GetAllBookQuery.Response> GetAllBook()
            => await _mediator.Send(new GetAllBookQuery.Request());

        [HttpGet("GetById")]
        public async Task<GetByIdBookQuery.Response> GetById(int Id)
            => await _mediator.Send(new GetByIdBookQuery.Request { Id = Id });

        [HttpPost("Add")]
        public async Task<Unit> Add(Book book)
            => await _mediator.Send(new CreateBookCommand.Request { Book = book });

        [HttpPut("Update")]
        public async Task<Unit> Update(Book book)
            => await _mediator.Send(new UpdateBookCommand(book));

        [HttpDelete("Delete")]
        public async Task<Unit> Remove(int Id)
            => await _mediator.Send(new RemoveBookCommand(Id));
    }
}
