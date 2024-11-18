using BookStore.Dto.AuthorsDto;
using BookStore.Dto.GenersDto;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Dto.CreateBookDto
{
    public class CreateBookDto
    {
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedYear { get; set; }
        public IEnumerable<int> AuthorsIds { get; set; } = Enumerable.Empty<int>();
        public IEnumerable<int> GenersIds { get; set; } = Enumerable.Empty<int>();
    }
}
