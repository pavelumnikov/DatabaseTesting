using DatabaseTesting.ApplicationLayer.Domain;
using FluentNHibernate.Mapping;

namespace DatabaseTesting.ApplicationLayer.DAL.Mappings
{
    public class MedicalBookEntityMapping : ClassMap<MedicalBookEntity>
    {
        public MedicalBookEntityMapping()
        {
            Table("MedicalBooks");

            Id(m => m.Id)
                .GeneratedBy.Assigned();

            Map(m => m.Number)
                .Not.Nullable();
        }
    }
}
