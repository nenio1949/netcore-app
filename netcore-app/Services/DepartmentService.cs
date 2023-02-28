using System;
using netcore_app.IServices;
using netcore_app.Models;
using netcore_app.Repositories;

namespace netcore_app.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentRepository _departmentRepository;
        public DepartmentService(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<Department>> ListAsync()
        {
            return await _departmentRepository.FindAllAsync();
        }

        public async Task<int> AddAsync(Department department)
        {
            return await _departmentRepository.AddAsync(department);

        }

        public async Task<bool> UpdateAsync(Department department)
        {
            return await _departmentRepository.UpdateAsync(department, department.Id);
        }

        public async Task<int> DeleteAsync(int[] ids)
        {
            return await _departmentRepository.DeleteAsync(ids);
        }
    }
}

