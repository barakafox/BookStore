using BookStore.Dto.AuthorsDto;
using BookStore.Dto.BooksDto;
using BookStore.Dto.CreateBookDto;
using BookStore.Dto.GenersDto;
using BookStore.Models.Data;
using BookStore.Models;
using BookStore.Dto.CreateAuthorDto;

namespace BookStore.Repositorys.AuthorRepo
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;

        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddAuthor(CreateAuthorDto authordto)
        {
            var author = new Author
            {
                AuthorName = authordto.AuthorName,
                Email = authordto.Email,
                Phone = authordto.Phone,
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                return false;
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return true;
        }

        public ICollection<AuthorDto> GetAuthor()
        {
            return _context.Authors.Select(x => new AuthorDto
            {
                AuthorName = x.AuthorName,
                Email = x.Email,
                Phone = x.Phone,
            }).ToList();
        }

        public AuthorDto? GetAuthorById(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                return null;
            }
            return new AuthorDto
            {
                AuthorName = author.AuthorName,
                Email = author.Email,
                Phone = author.Phone,
            };
        }


        public bool UpdateAuthor(CreateAuthorDto authordto, int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                return false;
            }
            author.AuthorName = authordto.AuthorName;
            author.Email = authordto.Email;
            author.Phone = authordto.Phone;

            _context.Update(author);
            _context.SaveChanges();
            return true;
        }
    }
}
