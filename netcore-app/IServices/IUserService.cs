using System;
using netcore_app.Models;

namespace netcore_app.IServices
{
	public interface IUserService
	{
        Task<List<User>> ListAsync();

        Task<int> AddAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<int> DeleteAsync(int[] ids);
    }
}

