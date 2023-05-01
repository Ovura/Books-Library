using Books_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_Library.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
        }


        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBorrowing> UserBorrowings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
               .HasData(
               new Book { Id = 1, Title = "Darkness at Noon", Author = "Arthur Kostler", ISBNNumber = 58974265 },
               new Book { Id = 2, Title = "Circle of Pain", Author = "Mary Smith", ISBNNumber = 756655656 },
               new Book { Id = 3, Title = "God Father", Author = "Mario Puzo", ISBNNumber = 123679458 }
               );
            modelBuilder.Entity<User>()
                .HasData(
                new User { Id = 1, FirstName = "Misha", LastName = "Samsson", Address = "Rörvägen 2", PhoneNumber = "0717894987" },
                new User { Id = 2, FirstName = "Tonny", LastName = "Jules", Address = "Kyrkgatan 12d ", PhoneNumber = "078452588" },
                new User { Id = 3, FirstName = "Leroy", LastName = "Henry", Address = "Storgatan 24", PhoneNumber = "0707456669" }
                );
            modelBuilder.Entity<UserBorrowing>()
                .HasData(
                new UserBorrowing { Id = 1, BorrowDate = new DateTime(2021, 12, 24), BookId = 1, UserId = 2, IsReturned = false },
                new UserBorrowing { Id = 2, BorrowDate = new DateTime(2021, 1, 12), BookId = 1, UserId = 1, IsReturned = true },
                new UserBorrowing { Id = 3, BorrowDate = new DateTime(2021, 2, 6), BookId = 2, UserId = 3, IsReturned = false },
                new UserBorrowing { Id = 4, BorrowDate = new DateTime(2020, 09, 13), BookId = 2, UserId = 2, IsReturned = false },
                new UserBorrowing { Id = 5, BorrowDate = new DateTime(2021, 07, 7), BookId = 3, UserId = 3, IsReturned = true }
                );
        }

    }
}
