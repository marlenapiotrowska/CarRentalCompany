namespace CarRentalCompany.Infrastructure;

public interface ITransaction
{
    bool IsStarted { get; }
    void Begin();
    void Commit();
    void Rollback();
}
