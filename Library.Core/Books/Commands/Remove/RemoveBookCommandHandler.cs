using Library.Infastructure.Persistence.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Remove
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand.Request,RemoveBookCommand.Response>
    {
        private readonly IBookRepositoryCommand _bookRepositoryCommand;

        public RemoveBookCommandHandler(IBookRepositoryCommand bookRepositoryCommand)
        {
            _bookRepositoryCommand = bookRepositoryCommand;
        }

        public async Task<RemoveBookCommand.Response> Handle(RemoveBookCommand.Request request, CancellationToken cancellationToken)
        {
            if (request.Id ==0 || request.Id<0)
                return new RemoveBookCommand.Response()
                {
                    Success = false
                };

            return new RemoveBookCommand.Response()
            {
                Success = await _bookRepositoryCommand.Remove(request.Id)
            };
        }
    }
}
