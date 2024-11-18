using BookStore.Dto.BooksDto;
using BookStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Dto.GenersDto
{
    public class GenerDto
    {
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public ICollection<BookDto>? BooksDto { get; set; }
    }
}
