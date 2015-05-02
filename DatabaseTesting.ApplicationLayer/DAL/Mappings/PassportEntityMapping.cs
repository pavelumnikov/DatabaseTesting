using DatabaseTesting.ApplicationLayer.Domain;
using FluentNHibernate.Mapping;

namespace DatabaseTesting.ApplicationLayer.DAL.Mappings
{
    public class PassportEntityMapping : ClassMap<PassportEntity>
    {
        public PassportEntityMapping()
        {
            Table("Passports");

            Id(m => m.Id)
                .GeneratedBy.Assigned();

            Map(m => m.Series)
                .Not.Nullable();

            Map(m => m.Number)
                .Not.Nullable();
        }
    }
}
