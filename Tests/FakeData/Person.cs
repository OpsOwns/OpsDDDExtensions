using OpsDDDExtensions.Abstraction.DDD;
using OpsDDDExtensions.Abstraction.DDD.Identity;
using OpsDDDExtensions.Extensions;
using System.Collections.Generic;

namespace OpsDDDExtensions.Tests.FakeData
{
    public class Person : Entity
    {
        public FullName FullName { get; set; }
        public Person(IdentityGuid id) : base(id)
        {
        }
    }
    public class AgeGen : ValueObject
    {
        public int Age { get; set; }

        private AgeGen(int age)
        {
            Age = age;
        }

        public static Result<AgeGen> Create(int age)
        {
            if (age < 30)
                return Result.Fail<AgeGen>("invalid age");
            return Result.Ok(new AgeGen(age));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Age;
        }
    }
    public class FullName : ValueObject
    {
        public string Name { get; set; }
        public string SureName { get; set; }

        private FullName(string name, string sureName)
        {
            Name = name;
            SureName = sureName;
        }

        public static Result<FullName> Create(string name, string sureName)
        {
            if (name is null)
                return Result.Fail<FullName>("invalid name");
            return Result.Ok(new FullName(name, sureName));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return SureName;
        }
    }

    public class PersonService
    {
        public List<Person> Persons { get; set; } = new();
        public void AddPerson(Person person)
        {
            Persons.Add(person);
        }
    }

}
