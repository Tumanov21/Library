using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand.Request>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(_ => _.AddCategoryDto).NotNull();
            RuleFor(_ => _.AddCategoryDto.Title).NotEmpty().NotNull();
        }
    }
}
