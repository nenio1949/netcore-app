using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using netcore_app.IRepositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using netcore_app.Models;

namespace netcore_app.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AppDbContext _context;

        public BaseRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {

            return await _context.Set<T>().ToListAsync();
        }

        public virtual T? Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual async Task<T?> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual int Add(T t)
        {

            _context.Set<T>().Add(t);
            return _context.SaveChanges();
        }

        public virtual async Task<int> AddAsync(T t)
        {
            _context.Set<T>().Add(t);
            return await _context.SaveChangesAsync();
        }

        public virtual T? Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public List<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual bool Update(T t, object key)
        {
            if (t == null)
                return false;
            T? exist = _context.Set<T>().Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                return _context.SaveChanges() == 1;
            }
            return false;
        }

        public virtual async Task<bool> UpdateAsync(T t, object key)
        {
            if (t == null)
                return false;
            T? exist = await _context.Set<T>().FindAsync(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                return (await _context.SaveChangesAsync()) == 1;
            }
            return false;
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public virtual void Save()
        {

            _context.SaveChanges();
        }

        public async virtual Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual List<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            List<T> query = _context.Set<T>().Where(predicate).ToList();
            return query;
        }

        public virtual async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
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

