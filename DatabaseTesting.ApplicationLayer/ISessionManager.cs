using NHibernate;

namespace DatabaseTesting.ApplicationLayer
{
    /// <summary>
    /// Session management class. Helps with session management in many-thread
    /// environment
    /// </summary>
    public interface ISessionManager
    {
        /// <summary>
        /// Retrieves current available session for thread.
        /// </summary>
        /// <returns>Thread-local session</returns>
        ISession GetSession();

        /// <summary>
        /// Drops current active session on thread.
        /// </summary>
        void DropSession();
    }
}
