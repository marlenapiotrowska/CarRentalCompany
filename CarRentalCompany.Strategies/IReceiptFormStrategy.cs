using CarRentalCompany.Application.Builders;

namespace CarRentalCompany.Strategies
{
    public interface IReceiptFormStrategy
    {
        IReceiptFormBuilder ResolveReceiptForm(string key);
    }
}
