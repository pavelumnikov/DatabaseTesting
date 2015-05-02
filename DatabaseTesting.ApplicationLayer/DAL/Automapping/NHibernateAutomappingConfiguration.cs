using System;
using DatabaseTesting.ApplicationLayer.Domain;
using FluentNHibernate.Automapping;

namespace DatabaseTesting.ApplicationLayer.DAL.Automapping
{
    public class NHibernateAutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.IsAssignableFrom(typeof(IEntity<>)) && type.Name != typeof(Entity<>).Name;
        }
    }
}
