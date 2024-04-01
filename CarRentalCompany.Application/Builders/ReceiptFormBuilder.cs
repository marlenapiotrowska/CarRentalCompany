using System.Text;

namespace CarRentalCompany.Application.Builders
{
    internal class ReceiptFormBuilder
    {
        private readonly StringBuilder _stringBuilder;

        public ReceiptFormBuilder()
        {
            _stringBuilder = new StringBuilder();
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
    }
}
