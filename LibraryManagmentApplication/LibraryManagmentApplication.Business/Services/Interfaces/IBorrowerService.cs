using LibraryManagmentApplication.Core.Models;

namespace LibraryManagmentApplication.Business.Services.Interfaces;

public interface IBorrowerService
{
    Task DeleteAsync(int id);
    Task CreateAsync(Borrower borrower);
    List<Borrower> GetAll();
    Task UpdateAsync(Borrower borrower);
}
