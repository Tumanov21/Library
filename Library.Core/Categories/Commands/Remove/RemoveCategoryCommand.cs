using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Categories.Commands.Remove
{
    public class RemoveCategoryCommand
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }
        public class Response
        {
            public bool Success { get; set; }
        }
    }
}
