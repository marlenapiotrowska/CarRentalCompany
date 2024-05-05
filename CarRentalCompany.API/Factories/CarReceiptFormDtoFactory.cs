using CarRentalCompany.API.Objects.ResponseModels;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.API.Factories
{
    public class CarReceiptFormDtoFactory : ICarReceiptFormDtoFactory
    {
        public CarReceiptFormDto Create(CarReceiptForm form)
        {
            var value = form.Activities?
                    .Select(GetActivity)
                    .ToList();

            return new CarReceiptFormDto
            {
                Id = form.Id,
                Type = form.Type,
                Value = string.Join(", ", value) ?? string.Empty,
                ClientId = form.ClientId
            };
        }

        private static string GetActivity(ActivityInstance activity)
        {
            if (activity.Payload == string.Empty)
            {
                return $"{activity.Name}";
            }

            return $"{activity.Name} {activity.Payload}";
        }
    }
}
