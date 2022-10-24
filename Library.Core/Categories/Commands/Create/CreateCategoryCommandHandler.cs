using Library.Infastructure.Persistence.Repositories.Command.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand.Request,CreateCategoryCommand.Response>
    {
        private readonly ICategoryRepositoryCommand _categoryRepositoryCommand;

        public CreateCategoryCommandHandler(ICategoryRepositoryCommand categoryRepositoryCommand)
        {
            _categoryRepositoryCommand = categoryRepositoryCommand;
        }

        public async Task<CreateCategoryCommand.Response> Handle(CreateCategoryCommand.Request request, CancellationToken cancellationToken)
        {
            if (request.AddCategoryDto is null)
                throw new ArgumentNullException();

            return new CreateCategoryCommand.Response()
            {
                Success = await _categoryRepositoryCommand.Add(request.AddCategoryDto)
            };
        }
    }
}
