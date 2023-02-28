using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_app.Models
{
    public class EntityBase : IEntity
    {
        [Key]
        [Description("主键")]
        public int Id { get; set; }

        [Description("创建时间")]
        public DateTime CreatedAt { get; set; }

        [Description("更新时间")]
        public DateTime UpdatedAt { get; set; }

        [Description("是否删除")]
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}

