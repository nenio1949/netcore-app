using System;
using netcore_app.Models;

namespace netcore_app.IRepositories
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<int> DeleteAsync(int[] ids);

    }
}

