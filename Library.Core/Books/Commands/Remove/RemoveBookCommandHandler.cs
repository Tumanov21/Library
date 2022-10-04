using Library.Infastructure.Data.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Remove
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand>
    {
        private readonly IBookRepositoryCommand _bookRepositoryCommand;

        public RemoveBookCommandHandler(IBookRepositoryCommand bookRepositoryCommand)
        {
            _bookRepositoryCommand = bookRepositoryCommand;
        }

        public async Task<Unit> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepositoryCommand.Remove(request.Id);
            return Unit.Value;
        }
    }
}
