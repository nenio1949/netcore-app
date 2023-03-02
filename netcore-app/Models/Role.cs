using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_app.Models
{
    [Table("Role")]
    public class Role : EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 权限
        /// </summary>
        [Description("权限")]
        [Column(TypeName = "text")]
        public string? Permission { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        [Column(TypeName = "text")]
        public string? Remark { get; set; }
    }
}

