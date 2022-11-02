using System;
using System.Linq;
using System.Reflection;
using Validation.Attributes;

namespace Validation
{
    public static class Validator
    {
        public static ValidationResult Validate(object obj)
        {
            foreach (var property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = property.GetValue(obj);
                var attributes = property.GetCustomAttributes(true).Cast<Attribute>().ToList();
                if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                {
                    foreach (var attribute in attributes)
                    {
                        if (attribute.GetType() == typeof(NotNullAttribute))
                        {
                            if (value == null)
                                return ValidationResult.Error("Not null value is required", property.Name);
                        }

                        if (attribute.GetType() == typeof(BetweenAttribute))
                        {
                            var min = (int?) ((BetweenAttribute) attribute).Min;
                            var max = (int?) ((BetweenAttribute) attribute).Max;
                            var val = (int?) value;
                            if (min.Value > val)
                                return ValidationResult.Error($"Value greater than {min} is required", property.Name);
                            if (max.Value < val)
                                return ValidationResult.Error($"Value less than {max} is required", property.Name);
                        }
                    }
                }

                if (property.PropertyType == typeof(string))
                {
                    foreach (var attribute in attributes)
                    {
                        if (attribute.GetType() == typeof(NotNullAttribute))
                        {
                            if (value == null)
                                return ValidationResult.Error("Not null value is required", property.Name);
                        }

                        if (attribute.GetType() == typeof(MaxLengthAttribute))
                        {
                            var maxLength = ((MaxLengthAttribute) attribute).MaxLength;
                            var val = (string) value;
                            if (val != null && val.Length > maxLength)
                                return ValidationResult.Error("String is too long", property.Name);
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
