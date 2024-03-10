using CarRentalCompany.Application.Builders;
using CarRentalCompany.Strategies.CarBrands;

namespace CarRentalCompany.Strategies
{
    public class ReceiptFormStrategy : IReceiptFormStrategy
    {
        private readonly Dictionary<string, ICarReceiptForm> _receiptFormStrategy;
        private readonly IEnumerable<IReceiptFormBuilder> _builders;

        public ReceiptFormStrategy(IEnumerable<IReceiptFormBuilder> builders)
        {
            _receiptFormStrategy = new Dictionary<string, ICarReceiptForm>
                    {
                        { "Typical", new CarReceiptForm() },
                        { "Porsche", new PorscheReceiptForm() },
                        { "Mercedes", new MercedesReceiptForm() },
                        { "Volvo", new VolvoReceiptForm() },
                    };

            _builders = builders;
        }

        public IReceiptFormBuilder ResolveReceiptForm(string key)
        {
            if (_receiptFormStrategy.TryGetValue(key, out var receiptForm))
            {
                return _builders.SingleOrDefault(b => b.IsReceiptFormType(receiptForm))
                        ?? throw new InvalidOperationException($"There is no possibility to create a receipt form with {key} value");
            }

            throw new InvalidOperationException($"There is no receipt form for {key}");
        }
    }
}
