
namespace CarRentalCompany.Domain.CarBrands
{
    public class ReceiptFormTypes
    {
        public static Dictionary<int, string> Types
            => GetTypes();

        public static Dictionary<int, string> Create(int type)
        {
            return Types
                .Where(t => t.Key.Equals(type))
                .ToDictionary(t => t.Key, t => t.Value);
        }

        private static Dictionary<int, string> GetTypes()
        {
            return new Dictionary<int, string>
            {
                { 1, "Typical" },
                { 2, "Porsche" },
                { 3, "Mercedes" },
                { 4, "Volvo" }
            };
        }
    }
}
