using System;

namespace DatabaseTesting.ApplicationLayer
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
