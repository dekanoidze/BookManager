using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.Application.Features;
using BookManager.Application.Interfaces;
using BookManager.Domain.Entities;
using MediatR;

namespace BookManager.Application.Features.Books.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBookRepository _repository;

        public CreateBookCommandHandler(IBookRepository repository)
        {
           _repository = repository;
        }

        public async Task<Guid> Handle(CreateBookCommand request,CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Author = request.Author,
                Year = request.Year,
            };
            await _repository.AddAsync(book);
            return book.Id;
        }

    }
}
