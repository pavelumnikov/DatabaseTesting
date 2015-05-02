using System;
using System.Threading;
using NHibernate;

namespace DatabaseTesting.ApplicationLayer.DAL
{
    public class NHibernateSessionManager : ISessionManager
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ThreadLocal<ISession> _currentSesionThreadLocal; 

        public NHibernateSessionManager(ISessionFactory sessionFactory)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");

            _sessionFactory = sessionFactory;
            _currentSesionThreadLocal = new ThreadLocal<ISession>();
        }

        public ISession GetSession()
        {
            return _currentSesionThreadLocal.Value ?? 
                (_currentSesionThreadLocal.Value = _sessionFactory.OpenSession());
        }

        public void DropSession()
        {
            if (_currentSesionThreadLocal.Value != null)
            {
                _currentSesionThreadLocal.Value.Dispose();
                _currentSesionThreadLocal.Value = null;
            }
        }
    }
}
