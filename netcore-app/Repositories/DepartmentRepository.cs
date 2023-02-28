using System;
using Microsoft.EntityFrameworkCore;
using netcore_app.IRepositories;
using netcore_app.Models;

namespace netcore_app.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> DeleteAsync(int[] ids)
        {
            if (ids.Length > 0)
            {
                var departmentQuery = _context.Set<Department>().AsQueryable();
                var list = await (from b in departmentQuery where ids.Contains(b.Id) && b.Deleted.Equals(false) select b).ToListAsync();
                list.ForEach(item =>
                {
                    item.Deleted = true;
                });
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}

