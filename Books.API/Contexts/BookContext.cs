using Books.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Books.API.Contexts
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FirstName = "George",
                    LastName = "RR Martin"
                },
                new Author
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FirstName = "Stephen",
                    LastName = "Fry"
                },
                new Author
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FirstName = "James",
                    LastName = "Elroy"
                },
                new Author
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FirstName = "Douglas",
                    LastName = "Adams"
                });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    AuthorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "The Winds of Winter",
                    Description = "The book that seems impossible to write."
                },
                new Book
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    AuthorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "A Game of Thrones",
                    Description = "A Game of Thrones is the first novel on A Song of Ice...."
                },
                new Book
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    AuthorId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Title = "Mythos",
                    Description = "The Greek myths are amongst the best stories ever told..."
                },
                new Book
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    AuthorId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Title = "American Tabloid",
                    Description = "American Tabloid is a 1995 novel by James Ellroy..."
                },
                new Book
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    AuthorId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description = "In The Hitchhiker's Guide to the Galaxy...."
                });
        }
    }
}
