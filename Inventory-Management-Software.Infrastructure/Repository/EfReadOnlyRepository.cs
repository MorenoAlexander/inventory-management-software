using Inventory_Management_Software.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_Software.Infrastructure.Repository;

public class EfReadOnlyRepository<T> : IEfReadOnlyRepository<T> where T : class
{
    protected readonly GenericIMSContext _context;
    
    public EfReadOnlyRepository(GenericIMSContext context)
    {
        _context = context;
    }

    public virtual ValueTask<T?> GetByIdAsync(Guid id)
    {
        return _context.Set<T>().FindAsync(id);
    }

    public virtual ValueTask<T?> GetByIdAsync(int id)
    {
        return _context.Set<T>().FindAsync(id);
    }

    public virtual T? GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    public virtual T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public virtual Task<List<T>> ListAllAsync()
    {
        return _context.Set<T>().ToListAsync();
    }

    public virtual List<T> ListAll()
    {
        return _context.Set<T>().ToList();
    }

    public virtual IQueryable<T> AsQueryable()
    {
        return _context.Set<T>().AsQueryable();
    }
}