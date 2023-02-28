using System;
using netcore_app.Models;
namespace netcore_app.IRepositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<int> DeleteAsync(int[] ids);
    }
}

