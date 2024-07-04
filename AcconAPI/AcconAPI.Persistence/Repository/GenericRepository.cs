using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using AcconAPI.Persistence.Context;

namespace AcconAPI.Persistence.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly AcconAPIDbContext _context;
    private IDbContextTransaction _transaction;

    public GenericRepository(AcconAPIDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        return tracking ? query : query.AsNoTracking();
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        return tracking ? query : query.AsNoTracking();
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        return tracking ? await query.SingleOrDefaultAsync(method) : await query.AsNoTracking().SingleOrDefaultAsync(method);
    }

    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        return tracking ? await query.SingleOrDefaultAsync(e => e.Id == Guid.Parse(id)) : await query.AsNoTracking().SingleOrDefaultAsync(e => e.Id == Guid.Parse(id));
    }

    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return await SaveAsync() > 0;
    }

    public bool Remove(T model)
    {
        Table.Remove(model);
        return SaveAsync().Result > 0;
    }

    public bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return SaveAsync().Result > 0;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return false;
        Table.Remove(entity);
        return await SaveAsync() > 0;
    }

    public bool Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    // Transaction methods implementation
    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

}
