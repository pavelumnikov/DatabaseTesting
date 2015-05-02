using System;
using System.Collections.Generic;
using NHibernate.Linq;

namespace DatabaseTesting.ApplicationLayer.DAL
{
    public class NHibernateRepository<TEntity, TId> : IRepository<TEntity, TId>
    {
        private readonly ISessionManager _sessionManager;

        public NHibernateRepository(ISessionManager sessionManager)
        {
            if (sessionManager == null)
                throw new ArgumentNullException("sessionManager");

            _sessionManager = sessionManager;
        }

        public void Add(TEntity entity)
        {
            var currentSesion = _sessionManager.GetSession();
            var guid = currentSesion.Save(entity);
            Console.WriteLine(guid);
        }

        public void Update(TEntity entity)
        {
            var currentSesion = _sessionManager.GetSession();
            currentSesion.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            var currentSesion = _sessionManager.GetSession();
            currentSesion.Delete(entity);
        }

        public TEntity GetById(TId id)
        {
            var currentSesion = _sessionManager.GetSession();
            return currentSesion.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            var currentSesion = _sessionManager.GetSession();
            return currentSesion.Query<TEntity>();
        }
    }
}
