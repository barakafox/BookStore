using BookStore.Dto.CreateBookDto;
using BookStore.Repositorys.AuthorRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksRepo _repo;

        public BookController(IBooksRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public IActionResult GetAllBooks()
        {
            return Ok(_repo.GetBooks());
        }

        [HttpGet ("{id:int}Get Book By ID")]
        public IActionResult GetBook(int id)
        {
            return Ok(_repo.GetBookById(id));
        }

        [HttpPost ("Add Book")]

        public IActionResult CreateBook(CreateBookDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _repo.AddBook(dto);
            if(!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut ("Update Book")]

        public IActionResult UpdateBook(CreateBookDto dto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _repo.UpdateBook(dto,id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete ("Delete Book")]

        public IActionResult DeleteBook(int id)
        {
            var result = _repo.DeleteBook(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
