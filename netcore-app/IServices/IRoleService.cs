using System;
using netcore_app.Dto;
using netcore_app.Models;
namespace netcore_app.IServices
{
  public interface IRoleService
  {
    Task<PageResult<Role>> ListAsync(RolePageDto dto);

    Task<Role?> InfoAsync(int id);

    Task<int> AddAsync(Role role);

    Task<bool> UpdateAsync(Role role);

    Task<int> DeleteAsync(int[] ids);
  }
}

