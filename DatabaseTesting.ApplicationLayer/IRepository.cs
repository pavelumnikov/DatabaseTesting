using System.Collections.Generic;

namespace DatabaseTesting.ApplicationLayer
{
    public interface IRepository<TEntity, TId>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(TId id);
        IEnumerable<TEntity> GetAll();
    }
}
