using Library.Core.Books.Commands.Create;
using Library.Core.Books.Commands.Remove;
using Library.Core.Books.Commands.Update;
using Library.Core.Books.Queries.GetAll;
using Library.Core.Books.Queries.GetById;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dto.BookDto;
using Library.Infrastructure.Persistence.Dtos.BookDtos;
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
        public async Task<CreateBookCommand.Response> Add(AddBookDto book)
            => await _mediator.Send(new CreateBookCommand.Request() { AddBookDto = book });

        [HttpPut("Update")]
        public async Task<UpdateBookCommand.Response> Update(UpdateBookDto book)
            => await _mediator.Send(new UpdateBookCommand.Request() { UpdateBookDto = book });

        [HttpDelete("Delete")]
        public async Task<Unit> Remove(int Id)
            => await _mediator.Send(new RemoveBookCommand(Id));
    }
}
