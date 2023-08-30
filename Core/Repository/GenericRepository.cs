using System.Linq.Expressions;
using DemoApp.Core.IRespository;
using DemoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Core.Repository;

public class GenericRespository<T>:IGenericRespository<T> where T : class
{
    protected ApiDbContext _apiDbContext;
    protected DbSet<T> _dbSet;
    protected ILogger _logger;
    public GenericRespository(ApiDbContext apiDbContext,ILogger logger)
    {
        _apiDbContext = apiDbContext;
        _logger = logger;
        _dbSet = _apiDbContext.Set<T>();
    }
    public async Task<T> CreateAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }catch (Exception e)
        {
            _logger.LogError(e, "Error Adding entity", entity);
            return null;
        }
    }

    public async Task<bool>Delete(T entity)
    {
        try
        {
            _dbSet.Remove(entity);
            return true;
        }catch (Exception e)
        {
            _logger.LogError(e, "Error Removing entity", entity);
            return false;
        }
    }
    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
    {
        IQueryable<T> query =_dbSet;
        if (!tracked)
        {
            query = query.AsNoTracking();
        }
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return await query.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
    {
        IQueryable<T> query = _dbSet;
        if (!tracked)
        {
            query = query.AsNoTracking();
        }
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return await query.FirstOrDefaultAsync();
    }

    public async Task<T> Update(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            return entity;
        }catch (Exception ex)
        {
            _logger.LogError(ex, "Error Updating entity", entity);
            return null;
        }
    }
}