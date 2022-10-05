using Library.Infastructure.Data.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepositoryCommand _categoryRepositoryCommand;

        public UpdateCategoryCommandHandler(ICategoryRepositoryCommand categoryRepositoryCommand)
        {
            _categoryRepositoryCommand = categoryRepositoryCommand;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepositoryCommand.Update(request.Category);
            return Unit.Value;
        }
    }
}
