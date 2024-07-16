using LibraryManagmentApplication.Business.Services.Interfaces;
using LibraryManagmentApplication.Core.Models;
using LibraryManagmentApplication.Core.Repositories;
using LibraryManagmentApplication.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentApplication.Business.Services.Implementations;

public class BookService : IBookService
{
    IBookRepository _bookRepository;

    public BookService()
    {
        _bookRepository = new BookRepository();
    }

    public async Task CreateAsync(Book book)
    {
        await _bookRepository.Insert(book);
        await _bookRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _bookRepository.GetAsync(id);

        if (data is null)
            throw new NullReferenceException($"Book with {id} id is not found!");

        _bookRepository.Delete(data);
        _bookRepository.CommitAsync();
    }

    public List<Book> FilterBooksByAuthor(string authorName)
    {
        return _bookRepository.GetAll()
                .Include(x => x.BookAuthors)
                .ThenInclude(y => y.Author)
                .Where(x => x.BookAuthors.Any(y => y.Author.Name.Contains(authorName)))
                .ToList();
    }

    public List<Book> FilterBooksByTitle(string title)
    {
        return _bookRepository.GetAll()
                .Where(x => x.Title.Contains(title))
                .ToList();
    }

    public List<Book> GetAll()
    {
        return  _bookRepository.GetAll().ToList();
    }

    public async Task UpdateAsync(Book book)
    {
        var existData = await _bookRepository.GetAsync(book.Id);

        if (existData is null)
            throw new NullReferenceException($"Book with {book.Id} id is not found!");

        existData.Title = book.Title;
        existData.Description = book.Description;
        existData.PublishedYear = book.PublishedYear;
        await _bookRepository.CommitAsync();
    }
}
