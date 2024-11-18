using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedYear { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Gener> Geners { get; set; } = new List<Gener>();
    }
}
