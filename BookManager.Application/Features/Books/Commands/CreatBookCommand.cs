using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookManager.Application.Features.Books.Commands
{
    public class CreateBookCommand: IRequest<Guid>
    {
        public string Title {  get; set; }

        public string Author {  get; set; }

        public int Year {  get; set; }
    }
}
