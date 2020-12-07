using System.Reflection;

namespace Asys.LaunchOptions
{
    internal class LaunchProperty
    {
        public LaunchProperty(LaunchAttribute attribute, PropertyInfo property)
        {
            Attribute = attribute;
            Property = property;
        }

        public LaunchAttribute Attribute { get; }

        public PropertyInfo Property { get; }
    }
}
