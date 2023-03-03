using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using netcore_app.IRepositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using netcore_app.Models;
using System.Linq;
using netcore_app.Common;

namespace netcore_app.Repositories
{
  public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected AppDbContext _context;

    public BaseRepository(AppDbContext dbContext)
    {
      _context = dbContext;
    }

    public virtual async Task<int> AddAsync(T entity)
    {
      _context.Set<T>().Add(entity);
      var res = await _context.SaveChangesAsync();
      _context.Entry(entity);
      return res;
    }

    public virtual async Task<bool> UpdateAsync(T entity, int id)
    {
      if (entity == null)
        return false;
      T? exist = await _context.Set<T>().FindAsync(id);
      if (exist != null)
      {
        _context.Entry(exist).CurrentValues.SetValues(entity);
        return (await _context.SaveChangesAsync()) == 1;
      }
      return false;
    }

    public virtual async Task<int> DeleteAsync(T entity)
    {
      _context.Set<T>().Remove(entity);
      return await _context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> where)
    {
      return await _context.Set<T>().Where(where).CountAsync();
    }


    public virtual async Task<T?> GetAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }



    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> where)
    {
      return await _context.Set<T>().SingleOrDefaultAsync(where);
    }


    public async Task<PageResult<T>> GetListAsync(Expression<Func<T, bool>> where, bool pagination = true, int page = 1, int size = 20, string order = "", bool orderDesc = true)
    {

      var query = _context.Set<T>().Where(where);
      if (pagination && page > 0 && size > 0)
      {
        query.Skip((page - 1) * size).Take(size);
      }
      if (!string.IsNullOrEmpty(order))
      {
        query.OrderBy(order, orderDesc);
      }
      var total = await _context.Set<T>().Where(where).CountAsync();
      var list = await _context.Set<T>().Where(where).ToListAsync();
      return new PageResult<T>() { List = list, Total = total };
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
        this.disposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}

