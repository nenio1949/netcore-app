using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcore_app.Services;
using netcore_app.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcore_app.Controllers
{
    [Route("v1/roles")]
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<List<Role>> List()
        {
            return await _roleService.ListAsync();
        }
    }
}

