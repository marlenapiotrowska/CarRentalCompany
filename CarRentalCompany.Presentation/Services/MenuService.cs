using CarRentalCompany.Application.Builders;
using CarRentalCompany.Strategies;
using CarRentalCompany.Strategies.CarBrands;

namespace CarRentalCompany.Presentation.Services
{
    internal class MenuService
    {
        private readonly IEnumerable<ICarReceiptForm> _carReceiptForms;
        private readonly IReceiptFormStrategy _strategy;
        private readonly IEnumerable<Dictionary<int, string>> _formTypes;

        public MenuService(IEnumerable<ICarReceiptForm> carReceiptForms, IReceiptFormStrategy strategy)
        {
            _carReceiptForms = carReceiptForms;
            _strategy = strategy;
            _formTypes = _carReceiptForms
                .Select(f => f.Type);
        }

        public void Render()
        {
            var reportWasSaved = false;

            while (reportWasSaved is false)
            {
                try
                {
                    CreateMenu();
                    var builder = GetBuilder();
                    builder.CreateEmpty();
                    builder.GetResult();
                    Console.WriteLine("\nRaport wygenerowano");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nWprowadzona wartość jest nieprawidłowa\n");
                    continue;
                }
            }
        }

        private void CreateMenu()
        {
            Console.WriteLine("-------Welcome in Incredible Maja's Car Rental-------" +
                            $"\nPress specific number to get empty receipt form for chose brand:");

            foreach (var element in _formTypes)
            {
                Console.WriteLine($"{element.First().Key}) {element.First().Value}");
            }
        }

        private IReceiptFormBuilder GetBuilder()
        {
            var pressedKey = Console.ReadKey().KeyChar;
            var numericValue = Convert.ToInt32(pressedKey.ToString());
            return _strategy.ResolveReceiptForm(numericValue);
        }
    }
}
