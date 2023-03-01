using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_app.Models
{
    [Table("Department")]
    public class Department : EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 父级部门
        /// </summary>
        public Department? Parent { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public User? Leader { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; } = string.Empty;
    }
}

