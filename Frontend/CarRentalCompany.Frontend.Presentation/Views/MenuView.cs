using CarRentalCompany.Frontend.Presentation.Views.Forms;
using CarRentalCompany.Frontend.Presentation.Views.Generic;

namespace CarRentalCompany.Frontend.Presentation.Views
{
    internal class MenuView : View
    {
        private readonly CarReceiptFormCreationView _formCreationView;

        public MenuView(CarReceiptFormCreationView formCreationView)
        {
            _formCreationView = formCreationView;
        }

        protected override async Task RenderViewAsync()
        {
            var wasExitKeyPressed = false;

            while (wasExitKeyPressed == false)
            {
                Console.WriteLine("---------WELCOME IN CAR RENTAL---------");
                Console.WriteLine
                    ("\n[1] To create new form" +
                    "\n[ESC] To quit");

                var pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        await _formCreationView.RenderAsync();
                        break;

                    case ConsoleKey.Escape:
                        wasExitKeyPressed = true;
                        break;

                    default: continue;
                }
            }
        }
    }
}
