using System;
namespace netcore_app.Common
{
    public class AutoInjectAttribute : Attribute
    {
        public Type TargetType { get; }

        public AutoInjectAttribute(Type targetType)
        {
            TargetType = targetType;
        }
    }
}

