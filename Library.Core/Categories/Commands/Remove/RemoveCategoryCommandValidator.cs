using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Remove
{
    public class RemoveCategoryCommandValidator : AbstractValidator<RemoveCategoryCommand.Request>
    {
        public RemoveCategoryCommandValidator()
        {
            RuleFor(_ => _.Id).Must(x => x != 0 && x < 0);
        }
    }
}
