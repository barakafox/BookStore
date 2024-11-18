using BookStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Dto.AuthorsDto
{
    public class AuthorDto
    {
        [StringLength(50)]
        public string AuthorName { get; set; } = string.Empty;
        [Phone, StringLength(50)]
        public string Phone { get; set; } = string.Empty;
        [EmailAddress, StringLength(50)]
        public string Email { get; set; } = string.Empty;
    }
}
