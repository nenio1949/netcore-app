using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_app.Models
{
    [Table("Department")]
    public class Department : EntityBase
    {
        [Description("名称")]
        [Required]
        public string Name { get; set; } = string.Empty;

        public Department? ParentDepartment { get; set; }

        public User? Leader { get; set; }

        [Description("备注")]
        public string Remark { get; set; } = string.Empty;
    }
}

