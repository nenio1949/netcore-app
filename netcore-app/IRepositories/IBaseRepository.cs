using System;
using System.Linq.Expressions;

namespace netcore_app.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        int Add(T t);
        Task<int> AddAsync(T t);
        int Count();
        Task<int> CountAsync();
        void Delete(T entity);
        Task<int> DeleteAsync(T entity);
        void Dispose();
        T? Find(Expression<Func<T, bool>> match);
        List<T> FindAll();
        List<T> FindAll(Expression<Func<T, bool>> match);
        Task<List<T>> FindAllAsync();
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T?> FindAsync(Expression<Func<T, bool>> match);
        List<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        T? Get(int id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        void Save();
        Task<int> SaveAsync();
        bool Update(T t, object key);
        Task<bool> UpdateAsync(T t, object key);
    }
}

