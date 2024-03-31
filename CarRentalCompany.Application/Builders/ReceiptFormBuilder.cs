using CarRentalCompany.Application.Repositories;
using CarRentalCompany.Domain.Models.CarBrands;
using System.Text;

namespace CarRentalCompany.Application.Builders
{
    internal class ReceiptFormBuilder
    {
        private readonly StringBuilder _stringBuilder;
        private readonly IReceiptFormRepository _repository;

        public ReceiptFormBuilder(IReceiptFormRepository repository)
        {
            _stringBuilder = new StringBuilder();
            _repository = repository;
        }

        public string GetDefaultReceiptForm()
        {
            _stringBuilder.AppendLine("Tire pressure: ");
            _stringBuilder.AppendLine("Fuel level: ");
            _stringBuilder.AppendLine("Car mileage: ");
            _stringBuilder.AppendLine("System updated: YES / NO");
            _stringBuilder.AppendLine("Refueled: YES / NO");
            _stringBuilder.AppendLine("Washed: ");

            return _stringBuilder.ToString();
        }

        public void SaveFile(StringBuilder builder)
        {
            var path = @"D:\4 - Maja sie uczy\4 - My apps\CarRentalCompanyFiles\ReceiptForm.txt";
            File.WriteAllText(path, builder.ToString());
        }

        public void AddReceiptForm(ICarReceiptForm receiptForm, Guid clientId)
        {
            _repository.Add(receiptForm, clientId);
        }
    }
}
