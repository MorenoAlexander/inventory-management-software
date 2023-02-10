using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_Software.Infrastructure.Repository;

public class EfRepository<T> : IEfRepository<T> where T : class, new() 
{
    private readonly DbContext _context;
    
    public EfRepository(GenericIMSContext context)
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

    public virtual Task AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        return _context.SaveChangesAsync();
    }

    public virtual T Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        return _context.SaveChangesAsync();
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public virtual Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return _context.SaveChangesAsync();
    }

    public virtual void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public IQueryable<T> AsQueryable()
    {
        return _context.Set<T>().AsQueryable();
    }
}