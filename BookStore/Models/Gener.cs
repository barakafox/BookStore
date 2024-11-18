using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Gener
    {
        public int GenerId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Book>? Books { get; set; }
    }
}
