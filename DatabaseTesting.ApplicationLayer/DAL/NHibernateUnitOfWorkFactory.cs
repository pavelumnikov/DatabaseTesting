using System;

namespace DatabaseTesting.ApplicationLayer.DAL
{
    public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISessionManager _sessionManager;

        public NHibernateUnitOfWorkFactory(ISessionManager sessionManager)
        {
            if (sessionManager == null)
                throw new ArgumentNullException("sessionManager");

            _sessionManager = sessionManager;
        }

        public IUnitOfWork Create()
        {
            return new NHibernateUnitOfWork(_sessionManager);
        }
    }
}
