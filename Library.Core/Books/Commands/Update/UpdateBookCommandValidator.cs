using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Update
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand.Request>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(_ => _.UpdateBookDto.Title).NotEmpty().NotNull();
            RuleFor(_ => _.UpdateBookDto.Id).Must(c => c != 0 && c < 0);
        }
    }
}
