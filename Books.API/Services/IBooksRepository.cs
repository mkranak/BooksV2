using Books.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.API.Services
{
    public interface IBooksRepository
    {
        void AddBook(Book bookToAdd);
        Book GetBook(Guid id);
        Task<Book> GetBookAsync(Guid id);
        IEnumerable<Book> GetBooks();  
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<Book>> GetBooksAsync(IEnumerable<Guid> bookIds);

        Task<bool> SaveChangesAsync();
    }
}
