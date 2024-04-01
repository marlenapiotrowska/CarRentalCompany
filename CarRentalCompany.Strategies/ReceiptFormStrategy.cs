using CarRentalCompany.Application.Builders;
using CarRentalCompany.Domain.Models.CarBrands;

namespace CarRentalCompany.Strategies
{
    public class ReceiptFormStrategy : IReceiptFormStrategy
    {
        private readonly IEnumerable<ICarReceiptForm> _carReceiptForms;
        private readonly IEnumerable<IReceiptFormBuilder> _builders;

        public ReceiptFormStrategy(IEnumerable<ICarReceiptForm> carReceiptForms,IEnumerable<IReceiptFormBuilder> builders)
        {
            _carReceiptForms = carReceiptForms;
            _builders = builders;
        }

        public IReceiptFormBuilder ResolveReceiptForm(int key)
        {
            var form = _carReceiptForms
                .FirstOrDefault(f => f.Type.ContainsKey(key));

            if (form != null)
            {
                return _builders.SingleOrDefault(b => b.IsReceiptFormType(form))
                        ?? throw new InvalidOperationException($"There is no possibility to create a receipt form with {key} value");
            }

            throw new InvalidOperationException($"There is no receipt form for {key}");
        }
    }
}
