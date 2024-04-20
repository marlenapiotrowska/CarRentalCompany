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

        public static ActivityInstance Create(Guid id, string payload, Guid activityDefinitionId, Guid receiptFormId)
        {
            return new ActivityInstance
            {
                Id = id,
                Payload = payload,
                ActivityDefinitionId = activityDefinitionId,
                ReceiptFormId = receiptFormId,
                IsCompleted = false
            };
        }

        public ActivityInstanceDomain CreateViewModel()
        {
            return new ActivityInstanceDomain(Id, ActivityDefinition.Name, Payload, ActivityDefinition.OrderNo, IsCompleted, ActivityDefinitionId, ReceiptFormId);
        }
    }
}
