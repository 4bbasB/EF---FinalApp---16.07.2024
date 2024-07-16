using LibraryManagmentApplication.Business.Services.Interfaces;
using LibraryManagmentApplication.Core.Models;
using LibraryManagmentApplication.Core.Repositories;
using LibraryManagmentApplication.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentApplication.Business.Services.Implementations;

public class BorrowerService : IBorrowerService
{
    IBorrowerRepository _borrowerRepository ;

    public BorrowerService()
    {
        _borrowerRepository = new BorrowerRepository();
    }
    public async Task CreateAsync(Borrower borrower)
    {
        await _borrowerRepository.Insert(borrower);
        await _borrowerRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _borrowerRepository.GetAsync(id);

        if (data is null)
            throw new NullReferenceException($"Author with {id} id is not found!");

        _borrowerRepository.Delete(data);
        _borrowerRepository.CommitAsync();
    }

    public List<Borrower> GetAll()
    {
        return  _borrowerRepository.GetAll().ToList();
    }

    public async Task UpdateAsync(Borrower borrower)
    {
        var existData = await _borrowerRepository.GetAsync(borrower.Id);

        if (existData is null)
            throw new NullReferenceException($"Borrower with {borrower.Id} id is not found!");

        existData.Name = borrower.Name;
        existData.Email = borrower.Email;

        await _borrowerRepository.CommitAsync();
    }
}
