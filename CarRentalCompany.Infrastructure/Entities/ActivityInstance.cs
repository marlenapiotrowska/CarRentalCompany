using ActivityInstanceDomain = CarRentalCompany.Domain.Models.ActivityInstance;

namespace CarRentalCompany.Infrastructure.Entities
{
    public class ActivityInstance
    {
        public Guid Id { get; set; }
        public string Payload { get; set; }
        public bool IsCompleted { get; set; }
        public Guid ActivityDefinitionId { get; set; }
        public virtual ActivityDefinition ActivityDefinition { get; set; }
        public Guid ReceiptFormId { get; set; }
        public virtual ReceiptForm ReceiptForm { get; set; }

        public static ActivityInstance Create(ActivityInstanceDomain activity, Guid formId)
        {
            return new ActivityInstance
            {
                Id = activity.Id,
                Payload = activity.Payload,
                ReceiptFormId = formId,
                IsCompleted = activity.IsCompleted
            };
        }

        public ActivityInstanceDomain CreateViewModel()
        {
            return new ActivityInstanceDomain(Id, ActivityDefinition.Name, Payload, ActivityDefinition.OrderNo, IsCompleted);
        }
    }
}
