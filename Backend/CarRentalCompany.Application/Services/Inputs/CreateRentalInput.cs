namespace CarRentalCompany.Application.Services.Inputs
{
    public class CreateRentalInput
    {
        public CreateRentalInput(Guid clientId, Guid carId)
        {
            ClientId = clientId;
            CarId = carId;
        }

        public Guid ClientId { get; }
        public Guid CarId { get; }
    }
}
