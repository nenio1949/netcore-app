using System;
using System.ComponentModel;

namespace netcore_app.Enums
{
	public enum UserGenderEnum
	{
		[Description("未知")]
		UnKnow=0,

        [Description("男")]
        Male = 1,

        [Description("女")]
        Female = 2,
    }

    public enum UserStatusEnum
    {
        [Description("正常")]
        Normal = 0,

        [Description("锁定")]
        Locked = 1,
    }
}

