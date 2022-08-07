using Library.Repositories.Interfaces;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Repositories;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService()
        {
        }

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddBookAsync(Book book)
        {
            _unitOfWork.GetRepository<Book>().Add(book);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var book = await GetBookByIdAsync(id);
            if(book != null)
            {
                _unitOfWork.GetRepository<Book>().Delete(book);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return (await _unitOfWork.GetRepository<Book>().AllAsync()).ToList();
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Book>().GetByIdAsync(id);
        }

        public async Task<bool> IsBookExistAsync(Guid id)
        {
            return (await _unitOfWork.GetRepository<Book>().FindAsync(book => book.Id == id)).Any();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _unitOfWork.GetRepository<Book>().Update(book);
            await _unitOfWork.CommitAsync();
        }
    }
}