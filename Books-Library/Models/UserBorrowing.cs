using System.ComponentModel.DataAnnotations;

namespace Books_Library.Models
{
    public class UserBorrowing
    {
        [Key]
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public bool IsReturned { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public int BookId { get; set; }
        public Book Book { get; set; } = default!;
    }
}
