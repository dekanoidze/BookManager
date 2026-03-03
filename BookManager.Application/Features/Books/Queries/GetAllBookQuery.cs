using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.Domain.Entities;
using MediatR;

namespace BookManager.Application.Features.Books.Queries
{
    public class GetAllBookQuery : IRequest<List<Book>>
    {

    }
}
