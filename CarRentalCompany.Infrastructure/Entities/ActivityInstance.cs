using ActivityInstanceDomain = CarRentalCompany.Domain.Models.ActivityInstance;

namespace CarRentalCompany.Infrastructure.Entities
{
    public class ActivityInstance
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Payload { get; set; }
        public bool IsCompleted { get; set; }
        public Guid ReceiptFormId { get; set; }
        public virtual ReceiptForm ReceiptForm { get; set; }

        public static ActivityInstance Create(ActivityInstanceDomain activity, Guid formId)
        {
            return new ActivityInstance
            {
                Id = activity.Id,
                Name = activity.Name,
                Payload = activity.Payload,
                ReceiptFormId = formId,
                IsCompleted = activity.IsCompleted
            };
        }
    }
}
