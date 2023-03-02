using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using netcore_app.Common;
using netcore_app.Enums;
using netcore_app.Models;

namespace netcore_app.Dto
{
    /// <summary>
    /// 用户新增dto
    /// </summary>
    [AutoInjectAttribute(typeof(User))]
    public class UserAddDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(5000)]
        public string? Avatar { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [Phone]
        [MaxLength(20)]
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(100)]
        public string? Email { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required]
        [DefaultValue(UserGenderEnum.UnKnow)]
        public UserGenderEnum gender { get; set; }

    }

    /// <summary>
    /// 用户更新dto
    /// </summary>
    [AutoInjectAttribute(typeof(User))]
    public class UserUpdateDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(5000)]
        public string Avatar { get; set; } = string.Empty;

        /// <summary>
        /// 部门id
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(20)]
        [Phone]
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 性别
        /// </summary>
        [DefaultValue(UserGenderEnum.UnKnow)]
        public UserGenderEnum gender { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DefaultValue(UserStatusEnum.Normal)]
        public UserStatusEnum status { get; set; }
    }

    /// <summary>
    /// 用户分页查询dto
    /// </summary>
    public class UserPageDto : PageDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }
    }
}

