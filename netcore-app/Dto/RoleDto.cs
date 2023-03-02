using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using netcore_app.Common;
using netcore_app.Models;

namespace netcore_app.Dto
{
    /// <summary>
    /// 角色新增dto
    /// </summary>
    [AutoInjectAttribute(typeof(Role))]
    public class RoleAddDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 权限
        /// </summary>
        public string? Permission { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }

    /// <summary>
    /// 角色更新dto
    /// </summary>
    [AutoInjectAttribute(typeof(Role))]
    public class RoleUpdateDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public string? Permission { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }

    /// <summary>
    /// 角色分页查询dto
    /// </summary>
    public class RolePageDto : PageDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
    }
}

