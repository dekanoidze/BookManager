using BookManager.Application.Features.Books.Commands;
using BookManager.Application.Features.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var book = await _mediator.Send(new GetAllBookQuery());
            return Ok(book);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookCommand bookCommand)
        {
            var id= await _mediator.Send(bookCommand);
            return Ok(id);
        }
    }
}
