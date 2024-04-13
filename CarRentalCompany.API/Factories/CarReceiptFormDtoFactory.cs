using CarRentalCompany.API.Objects.ResponseModels;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.API.Factories
{
    public class CarReceiptFormDtoFactory : ICarReceiptFormDtoFactory
    {
        public CarReceiptFormDto Create(CarReceiptForm form)
        {
            var value = form.Activities?
                    .Select(a => $"{a.Name} {a.Payload}")
                    .ToList();

            return new CarReceiptFormDto
            {
                Id = form.Id,
                Type = form.Type,
                Value = string.Join(", ", value) ?? string.Empty,
                ClientId = form.ClientId
            };
        }
    }
}
