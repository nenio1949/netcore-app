using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_app.Models
{
    [Table("Role")]
    public class Role : EntityBase
    {
        [Description("名称")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Description("权限")]
        [Column(TypeName = "text")]
        public string Permission { get; set; } = string.Empty;

        [Description("备注")]
        public string Remark { get; set; } = string.Empty;
    }
}

