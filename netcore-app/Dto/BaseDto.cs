using System;
using System.ComponentModel;

namespace netcore_app.Dto
{
  /// <summary>
  /// 分页dto
  /// </summary>
	public class PageDto
  {
    /// <summary>
    /// 当前页
    /// </summary>
		public int Page { get; set; } = 1;

    /// <summary>
    /// 当前页数据条数
    /// </summary>
		public int Size { get; set; } = 20;

    /// <summary>
    /// 是否分页(默认分页)
    /// </summary>
    [DefaultValue(true)]
    public bool Pagination { get; set; } = true;
  }
}

