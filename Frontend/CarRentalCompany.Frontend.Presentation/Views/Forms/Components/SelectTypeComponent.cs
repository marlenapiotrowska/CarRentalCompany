using CarRentalCompany.Frontend.Presentation.Views.Generic;

namespace CarRentalCompany.Frontend.Presentation.Views.Forms.Components
{
    internal class SelectTypeComponent : Component<string?>
    {
        public override string Render()
        {
            var wasExitKeyPressed = false;
            var result = string.Empty;

            while (!wasExitKeyPressed)
            {
                Console.Clear();
                Console.WriteLine("Select form type:");
                Console.WriteLine
                    ("\n[1] Basic form" +
                    "\n[2] Mercedes form" +
                    "\n[3] Porsche form" +
                    "\n[4] Volvo form");

                var pressedKey = Console.ReadKey();
                Console.ReadLine();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        result = "Mercedes";
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        result = "Porsche";
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        result = "Volvo";
                        break;

                    default: continue;
                }

                break;
            }

            return result;
        }
    }
}
