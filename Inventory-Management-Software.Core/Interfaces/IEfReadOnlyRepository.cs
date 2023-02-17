namespace Inventory_Management_Software.Core.Interfaces;

public interface IEfReadOnlyRepository<T> where T : class
{
    public ValueTask<T?> GetByIdAsync(Guid id);
    public ValueTask<T?> GetByIdAsync(int id);
    public T? GetById(Guid id);
    public T? GetById(int id);
    public Task<List<T>> ListAllAsync();
    public List<T> ListAll();
    public IQueryable<T> AsQueryable();
}