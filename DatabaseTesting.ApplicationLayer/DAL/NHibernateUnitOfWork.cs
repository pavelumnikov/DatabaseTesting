using System;
using NHibernate;

namespace DatabaseTesting.ApplicationLayer.DAL
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISessionManager _sessionManager;
        private readonly ITransaction _currentTransaction;

        public NHibernateUnitOfWork(ISessionManager sessionManager)
        {
            if (sessionManager == null)
                throw new ArgumentNullException("currentSession");

            _sessionManager = sessionManager;
            _currentTransaction = _sessionManager.GetSession().BeginTransaction();
        }

        public void Dispose()
        {
            _currentTransaction.Dispose();
            _sessionManager.DropSession();
        }

        public void Commit()
        {
            if(_currentTransaction.IsActive)
                _currentTransaction.Commit();
        }

        public void Rollback()
        {
            if (_currentTransaction.IsActive)
                _currentTransaction.Rollback();
        }
    }
}
