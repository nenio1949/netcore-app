using System;
using System.Linq.Expressions;
using netcore_app.Common;
using netcore_app.Dto;
using netcore_app.IRepositories;
using netcore_app.IServices;
using netcore_app.Models;
using netcore_app.Repositories;

namespace netcore_app.Services
{
  public class DepartmentService : IDepartmentService
  {
    private readonly IDepartmentRepository _departmentRepository;
    public DepartmentService(IDepartmentRepository departmentRepository)
    {
      _departmentRepository = departmentRepository;
    }

    public async Task<PageResult<Department>> ListAsync(DepartmentPageDto dto)
    {
      var where = ExpressionExtensions.GetTrue<Department>();
      where = where.And(p => p.Deleted == false);
      if (!string.IsNullOrEmpty(dto.Name))
      {
        where.And(p => p.Name.Contains(dto.Name));
      }
      return await _departmentRepository.GetListAsync(where, dto.Pagination, dto.Page, dto.Size);
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

