namespace DatabaseTesting.ApplicationLayer
{
    public interface IDatabaseConnection
    {
        string ConnectionString { get; }
        bool DatabaseExists { get; }

        void CreateDatabase();
        void DropDatabase();
    }
}
