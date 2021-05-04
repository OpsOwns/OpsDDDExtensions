using OpsDDDExtensions.Abstraction;
using OpsDDDExtensions.Abstraction.Identity;
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
                return Result<FullName>.Fail("invalid name");
            return Result<FullName>.Success(new (name, sureName));
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
