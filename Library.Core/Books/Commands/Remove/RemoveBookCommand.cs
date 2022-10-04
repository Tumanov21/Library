using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Remove
{
    public record RemoveBookCommand(Guid Id):IRequest;
}
