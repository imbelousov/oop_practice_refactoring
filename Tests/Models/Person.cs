using Validation.Attributes;

namespace Tests.Models
{
    public class Person
    {
        [NotNull] public string Name { get; set; }
        [Between(Min = 0, Max = 99)] public int Age { get; set; }
        [MaxLength(10)] public string Phone { get; set; }
    }
}
