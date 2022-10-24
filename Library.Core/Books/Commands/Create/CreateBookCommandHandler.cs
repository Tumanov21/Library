using Library.Infastructure.Persistence.Repositories.Command.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Create
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand.Request,CreateBookCommand.Response>
    {
        private readonly IBookRepositoryCommand _bookRepositoryCommand;

        public CreateBookCommandHandler(IBookRepositoryCommand bookRepositoryCommand)
        {
            _bookRepositoryCommand = bookRepositoryCommand;
        }

        public async Task<CreateBookCommand.Response> Handle(CreateBookCommand.Request request, CancellationToken cancellationToken)
        {
            if (request.AddBookDto is null)
                throw new ArgumentNullException();

            return new CreateBookCommand.Response()
            {
                Success = await _bookRepositoryCommand.Add(request.AddBookDto)
            };
        }
    }
}
