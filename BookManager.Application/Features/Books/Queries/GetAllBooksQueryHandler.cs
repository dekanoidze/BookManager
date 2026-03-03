using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.Application.Interfaces;
using BookManager.Domain.Entities;
using MediatR;

namespace BookManager.Application.Features.Books.Queries
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBookQuery, List<Book>>
    {
        private  readonly IBookRepository _repository;

        public GetAllBooksQueryHandler(IBookRepository repository)
        {
            _repository= repository;
        }

        public async Task<List<Book>> Handle(GetAllBookQuery request,CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }


    }
}
