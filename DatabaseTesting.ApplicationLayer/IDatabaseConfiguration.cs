namespace DatabaseTesting.ApplicationLayer
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseConfiguration
    {
        /// <summary>
        /// Gets current connection to a database.
        /// </summary>
        IDatabaseConnection Connection { get; }

        /// <summary>
        /// Creates a new session manager for selected database.
        /// </summary>
        /// <returns></returns>
        ISessionManager CreateSessionManager();
    }
}
