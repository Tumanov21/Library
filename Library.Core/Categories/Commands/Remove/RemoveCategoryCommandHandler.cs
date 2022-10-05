using Library.Infastructure.Data.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Remove
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepositoryCommand _categoryRepositoryCommand;

        public RemoveCategoryCommandHandler(ICategoryRepositoryCommand categoryRepositoryCommand)
        {
            _categoryRepositoryCommand = categoryRepositoryCommand;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepositoryCommand.Remove(request.id);
            return Unit.Value;
        }
    }
}
