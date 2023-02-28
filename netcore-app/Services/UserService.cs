using System;
using netcore_app.IServices;
using netcore_app.Models;
using netcore_app.Repositories;

namespace netcore_app.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> ListAsync()
        {
            return await _userRepository.FindAllAsync();
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

