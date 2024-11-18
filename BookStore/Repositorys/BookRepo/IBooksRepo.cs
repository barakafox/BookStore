using BookStore.Dto.BooksDto;
using BookStore.Dto.CreateBookDto;

namespace BookStore.Repositorys.AuthorRepo
{
    public interface IBooksRepo
    {
        ICollection<BookDto> GetBooks();
        BookDto? GetBookById(int id);
        bool AddBook(CreateBookDto bookdto); 
        bool UpdateBook(CreateBookDto bookdto, int id);
        bool DeleteBook(int id);
    }
}
