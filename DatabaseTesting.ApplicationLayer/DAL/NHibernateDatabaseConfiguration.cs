using System;
using DatabaseTesting.ApplicationLayer.DAL.Automapping;
using DatabaseTesting.ApplicationLayer.DAL.Mappings;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DatabaseTesting.ApplicationLayer.DAL
{
    public abstract class NHibernateDatabaseConfiguration : IDatabaseConfiguration
    {
        protected readonly IDatabaseConnection DatabaseConnection;

        protected NHibernateDatabaseConfiguration(IDatabaseConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");

            DatabaseConnection = connection;
        }

        public IDatabaseConnection Connection
        {
            get { return DatabaseConnection; }
        }

        public ISessionManager CreateSessionManager()
        {
            var sessionFactory = Fluently.Configure()
                .Database(CreateConfiguration).Mappings(m => Mappings(m))
                .ExposeConfiguration(BuildSchema).BuildSessionFactory();

            return new NHibernateSessionManager(sessionFactory);
        }

        public MappingConfiguration Mappings(MappingConfiguration mappings)
        {
            CustomMappings(mappings);
            return mappings;
        }

        protected void BuildSchema(Configuration configuration)
        {
            if (DatabaseConnection.DatabaseExists) 
                return;

            DatabaseConnection.CreateDatabase();
            new SchemaExport(configuration).Create(true, true);
        }

        protected virtual void CustomMappings(MappingConfiguration mapping)
        {
            mapping.FluentMappings.AddFromAssemblyOf<NHibernateDatabaseConfiguration>();

            //mapping.AutoMappings.Add(
            //    AutoMap.AssemblyOf<NHibernateDatabaseConfiguration>(new NHibernateAutomappingConfiguration())
            //    .Conventions.Setup(c =>
            //    {
            //        c.Add<NHibernatePrimaryKeyConvention>();
            //        c.Add<NHibernateForeignKeyConvention>();
            //        c.Add<NHibernateDefaultStringLengthConvention>();
            //    })
            //    .UseOverridesFromAssemblyOf<NHibernateDatabaseConfiguration>());
        }

        protected abstract IPersistenceConfigurer CreateConfiguration();
    }
}
