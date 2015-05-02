namespace DatabaseTesting.ApplicationLayer
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
