using NUnit.Framework;
using Tests.Models;
using Validation;

namespace Tests
{
    public class ValidatorTests
    {
        [Test]
        public void ValidModel()
        {
            var result = Validator.Validate(new Person
            {
                Name = "Ivan",
                Age = 40,
                Phone = "7777777"
            });
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void PhoneIsMissed()
        {
            var result = Validator.Validate(new Person
            {
                Name = "Ivan",
                Age = 40
            });
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void NameIsMissed()
        {
            var result = Validator.Validate(new Person
            {
                Age = 40
            });
            Assert.IsFalse(result.IsSuccess);
            Assert.That(result.ErrorProperty, Is.EqualTo(nameof(Person.Name)));
        }

        [Test]
        public void NegativeAge()
        {
            var result = Validator.Validate(new Person
            {
                Name = "Ivan",
                Age = -1,
                Phone = "7777777"
            });
            Assert.IsFalse(result.IsSuccess);
            Assert.That(result.ErrorProperty, Is.EqualTo(nameof(Person.Age)));
        }

        [Test]
        public void HugeAge()
        {
            var result = Validator.Validate(new Person
            {
                Name = "Ivan",
                Age = 9999,
                Phone = "7777777"
            });
            Assert.IsFalse(result.IsSuccess);
            Assert.That(result.ErrorProperty, Is.EqualTo(nameof(Person.Age)));
        }

        [Test]
        public void TooLongPhone()
        {
            var result = Validator.Validate(new Person
            {
                Name = "Ivan",
                Age = 40,
                Phone = "00000000000000000000000"
            });
            Assert.IsFalse(result.IsSuccess);
            Assert.That(result.ErrorProperty, Is.EqualTo(nameof(Person.Phone)));
        }
    }
}
