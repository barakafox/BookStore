using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [StringLength(50)]
        public string AuthorName { get; set; } = string.Empty;
        [Phone,StringLength(50)]
        public string Phone { get; set; } = string.Empty;
        [EmailAddress,StringLength(50)]
        public string Email { get; set; } = string.Empty;
        public ICollection<Book>? Books { get; set; }
    }
}
