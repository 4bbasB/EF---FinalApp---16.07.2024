using LibraryManagmentApplication.Business.Services.Interfaces;
using LibraryManagmentApplication.Core.Models;
using LibraryManagmentApplication.Core.Repositories;
using LibraryManagmentApplication.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentApplication.Business.Services.Implementations;

public class AuthorService : IAuthorService
{
    IAuthorRepository _authorRepository;

    public AuthorService()
    {
        _authorRepository = new AuthorRepository();
    }


    public async Task CreateAsync(Author author)
    {
        await _authorRepository.Insert(author);
        await _authorRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _authorRepository.GetAsync(id);

        if (data is null)
            throw new NullReferenceException($"Author with {id} id is not found!");

        _authorRepository.Delete(data);
        _authorRepository.CommitAsync();
    }

    public List<Author> GetAll()
    {
        return  _authorRepository.GetAll().ToList();
    }

    public async Task UpdateAsync(Author author)
    {
        var existData = await _authorRepository.GetAsync(author.Id);

        if (existData is null)
            throw new NullReferenceException($"Author with {author.Id} id is not found!");

        existData.Name = author.Name;

        await _authorRepository.CommitAsync();
    }
}
