using System;
using netcore_app.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using netcore_app.Common;

namespace netcore_app.Dto
{
    /// <summary>
    /// 部门新增dto
    /// </summary>
    [AutoInjectAttribute(typeof(Department))]
    public class DepartmentAddDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 父级部门id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 负责人id
        /// </summary>
        public int LeaderId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;
    }

    /// <summary>
    /// 部门更新dto
    /// </summary>
    [AutoInjectAttribute(typeof(Department))]
    public class DepartmentUpdateDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(50)]
        public string? Name { get; set; }

        /// <summary>
        /// 父级部门id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 负责人id
        /// </summary>
        public int LeaderId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }

    /// <summary>
    /// 部门分页查询dto
    /// </summary>
    public class DepartmentPageDto : PageDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 父级部门id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 负责人id
        /// </summary>
        public int LeaderId { get; set; }
    }
}

