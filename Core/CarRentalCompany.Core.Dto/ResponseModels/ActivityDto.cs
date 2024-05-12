namespace CarRentalCompany.Core.Dto.ResponseModels
{
    public class ActivityDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Payload { get; init; }
        public double OrderNo { get; init; }
        public bool IsCompleted { get; init; }
    }
}
