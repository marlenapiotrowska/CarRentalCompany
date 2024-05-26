using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Frontend.Presentation.Views.Generic;

namespace CarRentalCompany.Frontend.Presentation.Views.Forms.Components
{
    internal class SelectClientComponent : Component<ClientDto>
    {
        private readonly IEnumerable<ClientDto> _clients;

        public SelectClientComponent(IEnumerable<ClientDto> clients)
        {
            _clients = clients;
        }

        public override ClientDto Render()
        {
            var wasExitKeyPressed = false;
            ClientDto? selectedClient = null;

            while (!wasExitKeyPressed)
            {
                Console.WriteLine("Select client:");
                foreach (var client in _clients)
                {
                    Console.WriteLine($"{_clients.ToList().IndexOf(client) + 1} {client.Name}");
                }

                if (!int.TryParse(Console.ReadLine(), out int clientIndex))
                {
                    Console.WriteLine("You entered an invalid value.");
                    continue;
                }

                selectedClient = _clients
                    .SingleOrDefault(c => _clients.ToList().IndexOf(c) + 1 == clientIndex);

                if (selectedClient == null)
                {
                    Console.WriteLine("You entered an invalid value.");
                    continue;
                }
            }

            return selectedClient;
        }
    }
}
