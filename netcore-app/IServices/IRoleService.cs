using System;
using netcore_app.Models;
namespace netcore_app.IServices
{
    public interface IRoleService
    {
        Task<List<Role>> ListAsync();

        Task<int> AddAsync(Role role);

        Task<bool> UpdateAsync(Role role);

        Task<int> DeleteAsync(int[] ids);
    }
}

