using System;

namespace Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BetweenAttribute : Attribute
    {
        public object Min { get; set; }
        public object Max { get; set; }
    }
}
