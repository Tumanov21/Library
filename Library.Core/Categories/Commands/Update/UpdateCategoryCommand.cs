using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Update
{
    public record UpdateCategoryCommand(UpdateCategoryDto Category):IRequest;
}
