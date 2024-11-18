using BookStore.Dto.AuthorsDto;
using BookStore.Dto.BooksDto;
using BookStore.Dto.CreateAuthorDto;
using BookStore.Dto.CreateBookDto;

namespace BookStore.Repositorys.AuthorRepo
{
    public interface IAuthorRepo
    {
        ICollection<AuthorDto> GetAuthor();
        AuthorDto? GetAuthorById(int id);
        bool AddAuthor(CreateAuthorDto authordto);
        bool UpdateAuthor(CreateAuthorDto authordto, int id);
        bool DeleteAuthor(int id);
    }
}
