using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Queries.GetById
{
    public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery.Request>
    {
        public GetByIdBookQueryValidator()
        {
            RuleFor(_ => _.Id).Must(c => c != 0 && c < 0);
        }
    }
}
