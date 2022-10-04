using Library.Infastructure.Data.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand.Request, UpdateBookCommand.Response>
    {
        private readonly IBookRepositoryCommand _bookRepositoryCommand;

        public UpdateBookCommandHandler(IBookRepositoryCommand bookRepositoryCommand)
        {
            _bookRepositoryCommand = bookRepositoryCommand;
        }

        public async Task<UpdateBookCommand.Response> Handle(UpdateBookCommand.Request request, CancellationToken cancellationToken)
        {
            await _bookRepositoryCommand.Update(request.Id);
        }
    }
}
