using System;
using System.Linq.Expressions;
using netcore_app.Common.Extensions;
using netcore_app.Dto;
using netcore_app.IRepositories;
using netcore_app.IServices;
using netcore_app.Models;
using netcore_app.Repositories;

namespace netcore_app.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<PageResult<User>> ListAsync(UserPageDto dto)
    {
      Expression<Func<User, bool>> where = p => true;
      where = where.And(p => p.Deleted == false);
      if (!string.IsNullOrEmpty(dto.Name))
      {
        where.And(p => p.Name.Contains(dto.Name));
      }
      return await _userRepository.GetListAsync(where, dto.Pagination, dto.Page, dto.Size);
    }

    public async Task<int> AddAsync(User user)
    {
      return await _userRepository.AddAsync(user);

    }

    public async Task<bool> UpdateAsync(User user)
    {
      return await _userRepository.UpdateAsync(user, user.Id);
    }

    public async Task<int> DeleteAsync(int[] ids)
    {
      return await _userRepository.DeleteAsync(ids);
    }
  }
}

