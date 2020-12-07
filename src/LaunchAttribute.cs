using System;

namespace Asys.LaunchOptions
{
    public class LaunchAttribute : Attribute
    {
        public LaunchAttribute(LaunchAttributeType type)
        {
            Type = type;
        }

        public LaunchAttributeType Type { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsRequired { get; set; }
    }
}
