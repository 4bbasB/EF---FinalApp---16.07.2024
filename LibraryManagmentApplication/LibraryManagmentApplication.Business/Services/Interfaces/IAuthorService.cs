using LibraryManagmentApplication.Core.Models;

namespace LibraryManagmentApplication.Business.Services.Interfaces;

public interface IAuthorService
{
    Task DeleteAsync(int id);
    Task CreateAsync(Author author);
    List<Author> GetAll();
    Task UpdateAsync(Author author);
}
