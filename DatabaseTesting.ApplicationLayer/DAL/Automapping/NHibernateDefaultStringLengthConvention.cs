using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DatabaseTesting.ApplicationLayer.DAL.Automapping
{
    public class NHibernateDefaultStringLengthConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(250);
        }
    }
}
