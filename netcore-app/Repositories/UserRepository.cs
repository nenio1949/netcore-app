using System;
using netcore_app.Models;
using netcore_app.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace netcore_app.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> DeleteAsync(int[] ids)
        {
            if (ids.Length > 0)
            {
                var userQuery = _context.Set<User>().AsQueryable();
                var list = await (from b in userQuery where ids.Contains(b.Id) && b.Deleted.Equals(false) select b).ToListAsync();
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

