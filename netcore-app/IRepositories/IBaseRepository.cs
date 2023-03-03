using System;
using System.Linq.Expressions;

namespace netcore_app.IRepositories
{
  public interface IBaseRepository<T> where T : class
  {
    /// <summary>
    /// 新增一条记录
    /// </summary>
    /// <param name="entity">记录</param>
    /// <returns>int</returns>
    Task<int> AddAsync(T entity);

    /// <summary>
    /// 更新一条记录
    /// </summary>
    /// <param name="entity">记录</param>
    /// <param name="id">id</param>
    /// <returns>bool</returns>
    Task<bool> UpdateAsync(T entity, int id);

    /// <summary>
    /// 删除一条记录
    /// </summary>
    /// <param name="entity">记录</param>
    /// <returns>int</returns>
    Task<int> DeleteAsync(T entity);

    /// <summary>
    /// 获取记录总数
    /// </summary>
    /// <param name="where">条件</param>
    /// <returns>int</returns>
    Task<int> CountAsync(Expression<Func<T, bool>> where);

    /// <summary>
    /// 根据id获取指定记录
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>T?</returns>
    Task<T?> GetAsync(int id);

    /// <summary>
    /// 根据条件获取指定记录
    /// </summary>
    /// <param name="where">条件</param>
    /// <returns>T?</returns>
    Task<T?> GetAsync(Expression<Func<T, bool>> where);


    /// <summary>
    /// 根据条件获取列表记录
    /// </summary>
    /// <param name="where">条件</param>
    /// <param name="pagination">是否分页(默认分页)</param>
    /// <param name="page">当前页页码</param>
    /// <param name="size">每页数据条数</param>
    /// <param name="order">排序字段</param>
    /// <param name="orderDesc">是否倒序(默认为true倒序，false为正序)</param>
    /// <returns>PageResult<T></returns>
    Task<PageResult<T>> GetListAsync(Expression<Func<T, bool>> where, bool pagination = true, int page = 1, int size = 20, string order = "", bool orderDesc = true);


    void Dispose();

  }
}

