using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Create
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand.Request>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(_ => _.AddBookDto).NotNull();
            RuleFor(_ => _.AddBookDto.Title).NotEmpty().NotNull();
        }
    }
}
