using CarRentalCompany.API.Objects.ResponseModels;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.API.Factories
{
    public class CarReceiptFormDtoFactory : ICarReceiptFormDtoFactory
    {
        public CarReceiptFormDto Create(CarReceiptForm form)
        {
            return new CarReceiptFormDto
            {
                Id = form.Id,
                Type = form.Type,
                Activities = CreateActivityDto(form.Activities),
                ClientId = form.ClientId
            };
        }

        private IEnumerable<ActivityDto> CreateActivityDto(IEnumerable<ActivityInstance> activities)
        {
            var activitiesDto = new List<ActivityDto>();

            foreach (var activity in activities)
            {
                var activityDto = new ActivityDto
                {
                    Id = activity.Id,
                    Name = activity.Name,
                    Payload = activity.Payload,
                    OrderNo = activity.OrderNo,
                    IsCompleted = activity.IsCompleted,
                };

                activitiesDto.Add(activityDto);
            }

            return activitiesDto;
        }
    }
}
