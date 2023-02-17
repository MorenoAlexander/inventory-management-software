using Inventory_Management_Software.Core.Entities;

namespace Inventory_Management_Software.Core.Interfaces;

public interface IEfRepository<T> : IEfReadOnlyRepository<T> where T : class
{
    public Task AddAsync(T entity);
    public T Add(T entity);
    public Task UpdateAsync(T entity);
    public void Update(T entity);
    public Task DeleteAsync(T entity);
    public void Delete(T entity);
}
    