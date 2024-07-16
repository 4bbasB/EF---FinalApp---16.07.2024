namespace LibraryManagmentApplication.Core.Repositories;

public interface IGenericRepository<T> where T : class, new()
{
    Task Insert(T entity);
    Task<T?> GetAsync(int id);
    IQueryable<T> GetAll();
    void Delete(T entity);
    Task<int> CommitAsync();
}
