using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using netcore_app.Enums;

namespace netcore_app.Models
{
    [Table("User")]
    public class User : EntityBase
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Description("姓名")]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 账号
        /// </summary>
        [Description("账号")]
        [Required]
        [MaxLength(20)]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        [MaxLength(100)]
        [Required]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 头像
        /// </summary>
        [Description("头像")]
        [MaxLength(5000)]
        public string Avatar { get; set; } = string.Empty;

        /// <summary>
        /// 部门id
        /// </summary>
        [Description("部门id")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        [Description("角色id")]
        public int RoleId { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public Role? Role { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        [Required]
        [MaxLength(20)]
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 邮箱
        /// </summary>
        [Description("邮箱")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        [Required]
        [DefaultValue(UserGenderEnum.UnKnow)]
        public UserGenderEnum gender { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        [Required]
        [DefaultValue(UserStatusEnum.Normal)]
        public UserStatusEnum status { get; set; }
    }
}

