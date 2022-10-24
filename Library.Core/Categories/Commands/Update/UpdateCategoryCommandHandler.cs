using Library.Infastructure.Persistence.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand.Request,UpdateCategoryCommand.Response>
    {
        private readonly ICategoryRepositoryCommand _categoryRepositoryCommand;

        public UpdateCategoryCommandHandler(ICategoryRepositoryCommand categoryRepositoryCommand)
        {
            _categoryRepositoryCommand = categoryRepositoryCommand;
        }

        public async Task<UpdateCategoryCommand.Response> Handle(UpdateCategoryCommand.Request request, CancellationToken cancellationToken)
        {
            if (request.UpdateCategoryDto is null)
                throw new ArgumentNullException();

            return new UpdateCategoryCommand.Response()
            {
                Success = await _categoryRepositoryCommand.Update(request.UpdateCategoryDto)
            };
        }
    }
}
