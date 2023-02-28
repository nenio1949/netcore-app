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
        [Description("姓名")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Description("账号")]
        [Required]
        public string Account { get; set; } = string.Empty;

        [Description("密码")]
        [Required]
        public string Password { get; set; } = string.Empty;

        [Description("头像")]
        public string Avatar { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public int RoleId { get; set; }

        public Role? Role { get; set; }

        [Description("手机号")]
        [Required]
        public string Mobile { get; set; } = string.Empty;

        [Description("邮箱")]
        public string Email { get; set; } = string.Empty;

        [Description("性别")]
        [Required]
        [DefaultValue(UserGenderEnum.UnKnow)]
        public UserGenderEnum gender { get; set; }

        [Description("状态")]
        [Required]
        [DefaultValue(UserStatusEnum.Normal)]
        public UserStatusEnum status { get; set; }
    }
}

