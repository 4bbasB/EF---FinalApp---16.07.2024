using LibraryManagmentApplication.Core.Models;

namespace LibraryManagmentApplication.Business.Services.Interfaces;

public interface IBookService
{
    Task DeleteAsync(int id);
    Task CreateAsync(Book book);
    List<Book> GetAll();
    Task UpdateAsync(Book book);
    List<Book> FilterBooksByTitle(string title);
    List<Book> FilterBooksByAuthor(string authorName);
}
