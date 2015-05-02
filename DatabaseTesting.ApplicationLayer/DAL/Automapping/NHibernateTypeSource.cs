using System;
using System.Collections.Generic;
using FluentNHibernate;
using FluentNHibernate.Diagnostics;

namespace DatabaseTesting.ApplicationLayer.DAL.Automapping
{
    public class NHibernateTypeSource : ITypeSource
    {
        private readonly IEnumerable<Type> _types;

        public NHibernateTypeSource(params Type[] types)
        {
            _types = types;
        }

        public IEnumerable<Type> GetTypes()
        {
            return _types;
        }

        public string GetIdentifier()
        {
            return "NHibernateTypeSource";
        }

        public void LogSource(IDiagnosticLogger logger)
        {
        }
    }
}
