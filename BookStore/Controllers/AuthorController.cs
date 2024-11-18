using BookStore.Dto.CreateAuthorDto;
using BookStore.Dto.CreateBookDto;
using BookStore.Repositorys.AuthorRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _repo;

        public AuthorController(IAuthorRepo repo)
        {
            //repo
            _repo = repo;
        }

        [HttpGet ("Get All Author")]

        public IActionResult GetAllAuthor()
        {
            return Ok(_repo.GetAuthor());
        }

        [HttpGet("{id:int}Get Author By ID")]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(_repo.GetAuthorById(id));
        }

        [HttpPost("Add Author")]

        public IActionResult CreateAuthor(CreateAuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _repo.AddAuthor(dto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("Update Author")]

        public IActionResult UpdateAuthor(CreateAuthorDto dto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _repo.UpdateAuthor(dto, id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("Delete Author")]

        public IActionResult DeleteAuthor(int id)
        {
            var result = _repo.DeleteAuthor(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
