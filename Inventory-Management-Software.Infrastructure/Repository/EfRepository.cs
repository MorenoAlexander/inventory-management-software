using Inventory_Management_Software.Core.Entities;
using Inventory_Management_Software.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_Software.Infrastructure.Repository;

public class EfRepository<T> : EfReadOnlyRepository<T>,IEfRepository<T> where T : class, new()
{
    
     public EfRepository(GenericIMSContext context) : base(context)
    {
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
}