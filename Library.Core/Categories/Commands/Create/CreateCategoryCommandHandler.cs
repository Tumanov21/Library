using Library.Infastructure.Persistence.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepositoryCommand _categoryRepositoryCommand;

        public CreateCategoryCommandHandler(ICategoryRepositoryCommand categoryRepositoryCommand)
        {
            _categoryRepositoryCommand = categoryRepositoryCommand;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepositoryCommand.Add(request.Category);
            return Unit.Value;
        }
    }
}
