using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcore_app.Services;
using netcore_app.Models;
using netcore_app.Dto;
using AutoMapper;
using System.Text.Json;
using System.Text.Json.Serialization;
using netcore_app.IServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcore_app.Controllers
{
    [Route("v1/roles")]
    public class RoleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public RoleController(IMapper mapper, IRoleService roleService)
        {
            _mapper = mapper;
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<List<Role>> List()
        {
            return await _roleService.ListAsync();
        }

        [HttpPost]
        public async Task<int> Add(RoleAddDto dto)
        {
            var role = _mapper.Map<Role>(dto) ?? new Role();

            return await _roleService.AddAsync(role);
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, RoleUpdateDto dto)
        {
            var role = await _roleService.InfoAsync(id);
            if (role == null)
            {
                throw new Exception("角色不存在！");
            }
            role = _mapper.Map(dto,role);
            return await _roleService.UpdateAsync(role);
        }

        [HttpDelete("{ids}")]
        public async Task<int> Delete(string ids)
        {
            var idsArr = Array.ConvertAll(ids.Split(","), int.Parse);
            if (idsArr.Length == 0)
            {
                throw new Exception("未传入任何角色id！");
            }

            return await _roleService.DeleteAsync(idsArr);
        }
    }
}

