using BookStore.Dto.AuthorsDto;
using BookStore.Dto.BooksDto;
using BookStore.Dto.CreateBookDto;
using BookStore.Dto.GenersDto;
using BookStore.Models;
using BookStore.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositorys.AuthorRepo
{
    public class BooksRepo : IBooksRepo
    {
        private readonly AppDbContext _context;

        public BooksRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool AddBook(CreateBookDto bookdto)
        {
            var author = _context.Authors.Where(x=>bookdto.AuthorsIds.Contains(x.AuthorId)).ToList();
            var gener = _context.Geners.Where(x => bookdto.GenersIds.Contains(x.GenerId)).ToList();
            var book = new Book
            {
                Title = bookdto.Title,
                PublishedYear = bookdto.PublishedYear,
                Authors = author,
                Geners = gener,
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteBook(int id)
        {
           var book = _context.Books.Find(id);
            if(book == null)
            {
                return false;
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }

        public BookDto? GetBookById(int id)
        {
            var book = _context.Books.Include(x => x.Geners).
                Include(x => x.Authors).FirstOrDefault(x=>x.BookId == id);
            if(book == null)
            {
                return null;
            }
            return new BookDto
            {
                Title = book.Title,
                PublishedYear = book.PublishedYear,
                AuthorsDto = book.Authors.Select(x=> new AuthorDto
                {
                    AuthorName = x.AuthorName,
                    Email = x.Email,
                    Phone = x.Phone,
                }).ToList(),
                GenersDto = book.Geners.Select(x=> new GenerDto
                {
                    Name = x.Name,
                }).ToList(),
            };
        }

        public ICollection<BookDto> GetBooks()
        {
            return _context.Books.
                Include(x=>x.Geners).
                Include(x=>x.Authors).
                Select(b=> new BookDto
                {
                    Title=b.Title,
                    PublishedYear=b.PublishedYear,
                }).ToList();
        }

        public bool UpdateBook(CreateBookDto bookdto, int id)
        {
            var author = _context.Authors.Where(x => bookdto.AuthorsIds.Contains(x.AuthorId)).ToList();
            var gener = _context.Geners.Where(x => bookdto.GenersIds.Contains(x.GenerId)).ToList();
            var book = _context.Books.Find(id);
            if(book == null)
            {
                return false;
            }
                book.Title = bookdto.Title;
                book.PublishedYear = bookdto.PublishedYear;
                book.Authors = author;
                book.Geners = gener;

            _context.Books.Update(book);
            _context.SaveChanges();
            return true;
        }
    }
}
