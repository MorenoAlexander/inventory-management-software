using Inventory_Management_Software.Core.Entities;

namespace Inventory_Management_Software.Infrastructure.Repository;

public interface IEfRepository<T> where T : class
{
    public ValueTask<T?> GetByIdAsync(Guid id);
    public ValueTask<T?> GetByIdAsync(int id);
    public T? GetById(Guid id);
    public T? GetById(int id);
    public Task<List<T>> ListAllAsync();
    public List<T> ListAll();
    public Task AddAsync(T entity);
    public T Add(T entity);
    public Task UpdateAsync(T entity);
    public void Update(T entity);
    public Task DeleteAsync(T entity);
    public void Delete(T entity);
    public IQueryable<T> AsQueryable();
}
    