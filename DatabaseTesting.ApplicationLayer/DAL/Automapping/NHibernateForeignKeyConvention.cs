using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace DatabaseTesting.ApplicationLayer.DAL.Automapping
{
    public class NHibernateForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
                return type.Name + "_FK";
            
            return property.Name + "_FK";
        }
    }
}
