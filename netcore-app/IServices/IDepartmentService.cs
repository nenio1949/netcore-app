using System;
using netcore_app.Dto;
using netcore_app.Models;

namespace netcore_app.IServices
{
  public interface IDepartmentService
  {
    Task<PageResult<Department>> ListAsync(DepartmentPageDto dto);

    Task<int> AddAsync(Department department);

    Task<bool> UpdateAsync(Department department);

    Task<int> DeleteAsync(int[] ids);
  }
}

