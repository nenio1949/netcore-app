using System;
using netcore_app.Models;

namespace netcore_app.IServices
{
	public interface IDepartmentService
	{
        Task<List<Department>> ListAsync();

        Task<int> AddAsync(Department department);

        Task<bool> UpdateAsync(Department department);

        Task<int> DeleteAsync(int[] ids);
    }
}

