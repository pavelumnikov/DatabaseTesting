using DatabaseTesting.ApplicationLayer.Domain;
using FluentNHibernate.Mapping;

namespace DatabaseTesting.ApplicationLayer.DAL.Mappings
{
    public class PersonEntityMapping : ClassMap<PersonEntity>
    {
        public PersonEntityMapping()
        {
            Table("Persons");

            Id(m => m.Id)
                .GeneratedBy.Assigned();

            Map(m => m.FirstName)
                .Not.Nullable();

            Map(m => m.SecondName)
                .Not.Nullable();

            Map(m => m.ThirdName)
                .Not.Nullable();

            References(m => m.Passport)
                .ForeignKey();

            References(m => m.MedicalBook)
                .ForeignKey();
        }
    }
}
