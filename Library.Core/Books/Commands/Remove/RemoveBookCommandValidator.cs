using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Remove
{
    public class RemoveBookCommandValidator : AbstractValidator<RemoveBookCommand.Request>
    {
        public RemoveBookCommandValidator()
        {
            RuleFor(_ => _.Id).Must(x => x != 0 && x < 0);
        }
    }
}
