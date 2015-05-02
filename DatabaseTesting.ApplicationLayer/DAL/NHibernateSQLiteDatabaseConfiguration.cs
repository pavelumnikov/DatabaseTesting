using FluentNHibernate.Cfg.Db;

namespace DatabaseTesting.ApplicationLayer.DAL
{
    public class NHibernateSQLiteDatabaseConfiguration : NHibernateDatabaseConfiguration
    {
        public NHibernateSQLiteDatabaseConfiguration(IDatabaseConnection connection)
            : base(connection)
        {

        }

        protected override IPersistenceConfigurer CreateConfiguration()
        {
            return SQLiteConfiguration.Standard
                .ConnectionString(DatabaseConnection.ConnectionString);
        }
    }
}
