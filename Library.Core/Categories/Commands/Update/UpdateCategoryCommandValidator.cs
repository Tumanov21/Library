using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand.Request>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(_ => _.UpdateCategoryDto.Id).Must(c => c != 0 && c < 0);
            RuleFor(_ => _.UpdateCategoryDto.Title).NotEmpty().NotNull();
        }
    }
}
