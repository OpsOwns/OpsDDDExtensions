using System.Collections.Generic;
using OpsDDDExtensions.Abstraction;
using OpsDDDExtensions.Extensions;

namespace OpsDDDExtensions.Tests.FakeData
{
    public class Person : ValueObject
    {
        public string Name { get; set; }
        public string SureName { get; set; }

        private Person(string name, string sureName)
        {
            Name = name;
            SureName = sureName;
        }

        public static Result<Person> Create(string name, string sureName)
        {
            if (name is null)
                return Result<Person>.Fail("invalid name");
            return Result<Person>.Success(new Person(name, sureName));
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
