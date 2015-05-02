namespace DatabaseTesting.ApplicationLayer
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
