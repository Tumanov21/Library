using Library.Infastructure.Persistence.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Remove
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand.Request,RemoveCategoryCommand.Response>
    {
        private readonly ICategoryRepositoryCommand _categoryRepositoryCommand;

        public RemoveCategoryCommandHandler(ICategoryRepositoryCommand categoryRepositoryCommand)
        {
            _categoryRepositoryCommand = categoryRepositoryCommand;
        }

        public async Task<RemoveCategoryCommand.Response> Handle(RemoveCategoryCommand.Request request, CancellationToken cancellationToken)
        {
            if (request.Id == 0 || request.Id < 0)
                return new RemoveCategoryCommand.Response()
                {
                    Success = false
                };

            return new RemoveCategoryCommand.Response()
            {
                Success = await _categoryRepositoryCommand.Remove(request.Id)
            };
        }
    }
}
