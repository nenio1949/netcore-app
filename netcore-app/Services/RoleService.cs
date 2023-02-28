using System;
using netcore_app.IRepositories;
using netcore_app.IServices;
using netcore_app.Models;
using netcore_app.Repositories;
namespace netcore_app.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleRepository _roleRepository;
        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<Role>> ListAsync()
        {
            return await _roleRepository.FindAllAsync();
        }

        public async Task<int> AddAsync(Role role)
        {
            return await _roleRepository.AddAsync(role);

        }

        public async Task<bool> UpdateAsync(Role role)
        {
            return await _roleRepository.UpdateAsync(role, role.Id);
        }

        public async Task<int> DeleteAsync(int[] ids)
        {
            return await _roleRepository.DeleteAsync(ids);
        }
    }
}

