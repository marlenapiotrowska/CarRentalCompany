using System.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCompany.Infrastructure;

public class Transaction : ITransaction
{
    private readonly CarRentalCompanyDbContext _context;

    public Transaction(CarRentalCompanyDbContext context)
    {
        _context = context;
    }

    public bool IsStarted { get; private set; }

    public void Begin()
    {
        _context.Database.BeginTransaction(IsolationLevel.Serializable);
        IsStarted = true;
    }

    public void Commit()
    {
        _context.Database.CommitTransaction();
        IsStarted = false;
    }

    public void Rollback()
    {
        _context.Database.RollbackTransaction();
        IsStarted = false;
    }
}
