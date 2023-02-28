using System;
using netcore_app.Models;

namespace netcore_app.IRepositories
{
	public interface IUserRepository:IBaseRepository<User>
	{
        Task<int> DeleteAsync(int[] ids);
    }
}

