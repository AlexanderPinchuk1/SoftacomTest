using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<Book> GetBookByIdAsync(Guid id);

        Task<bool> IsBookExistAsync(Guid id);

        Task UpdateBookAsync(Book book);

        Task DeleteBookAsync(Guid id);

        Task AddBookAsync(Book book);
    }
}