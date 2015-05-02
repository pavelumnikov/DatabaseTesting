using System.Data.SQLite;
using System.IO;

namespace DatabaseTesting.ApplicationLayer.DAL
{
    public class NHibernateSQLiteDatabaseConnection : IDatabaseConnection
    {
        private readonly SQLiteConnectionStringBuilder _connectionStringBuilder;

        public NHibernateSQLiteDatabaseConnection(string filename)
        {
            _connectionStringBuilder = new SQLiteConnectionStringBuilder
            {
                DataSource = filename,
                Version = 3,
                BinaryGUID = false,
                CacheSize = 3000,
                JournalMode = SQLiteJournalModeEnum.Wal,
                SyncMode = SynchronizationModes.Full,
                DefaultTimeout = 100
            };
        }

        public string ConnectionString 
        {
            get { return _connectionStringBuilder.ConnectionString; }
        }

        public bool DatabaseExists
        {
            get { return File.Exists(_connectionStringBuilder.DataSource); }
        }

        public void CreateDatabase()
        {
            SQLiteConnection.CreateFile(_connectionStringBuilder.DataSource);
        }

        public void DropDatabase()
        {
            var path = _connectionStringBuilder.DataSource;
            if(File.Exists(path))
                File.Delete(path);
        }
    }
}
