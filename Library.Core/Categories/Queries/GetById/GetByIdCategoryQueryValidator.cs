using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Queries.GetById
{
    public class GetByIdCategoryQueryValidator : AbstractValidator<GetByIdCategoryQuery.Request>
    {
        public GetByIdCategoryQueryValidator()
        {
            RuleFor(_ => _.Id).Must(c => c != 0 && c < 0);
        }
    }
}
