using BookStore.Dto.AuthorsDto;
using BookStore.Dto.GenersDto;
using BookStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Dto.BooksDto
{
    public class BookDto
    {
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedYear { get; set; }
        public ICollection<AuthorDto> AuthorsDto { get; set; } = new List<AuthorDto>();
        public ICollection<GenerDto> GenersDto { get; set; } = new List<GenerDto>();
    }
}
