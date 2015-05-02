using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DatabaseTesting.ApplicationLayer.DAL.Automapping
{
    public class NHibernateManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            if (instance.OtherSide == null)
            {
                instance.Table(
                    string.Format("{0}To{1}",
                        instance.EntityType.Name,
                        instance.ChildType.Name));
            }
            else
            {
                instance.Inverse();
            }
        }
    }
}
