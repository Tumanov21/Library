﻿using Library.Infastructure.Data.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Create
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand.Request>
    {
        private readonly IBookRepositoryCommand _bookRepositoryCommand;

        public CreateBookCommandHandler(IBookRepositoryCommand bookRepositoryCommand)
        {
            _bookRepositoryCommand = bookRepositoryCommand;
        }

        public async Task<Unit> Handle(CreateBookCommand.Request request, CancellationToken cancellationToken)
        {
            await _bookRepositoryCommand.Add(request.Book);
            return Unit.Value;
        }
    }
}
