using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_app.Models
{
    public class EntityBase : IEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Description("是否删除")]
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}

