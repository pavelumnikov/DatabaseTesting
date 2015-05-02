using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DatabaseTesting.ApplicationLayer.DAL.Automapping
{
    public class NHibernatePrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
        }
    }
}
