using System;
using netcore_app.Dto;
using netcore_app.Models;

namespace netcore_app.IServices
{
  public interface IUserService
  {
    Task<PageResult<User>> ListAsync(UserPageDto dto);

    Task<int> AddAsync(User user);

    Task<bool> UpdateAsync(User user);

    Task<int> DeleteAsync(int[] ids);
  }
}

