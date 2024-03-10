namespace CarRentalCompany.Domain.AdditionalTypes
{
    public record Condition(int State)
    {
        public static Condition Good { get; } = new(1);
        public static Condition WithComments { get; } = new(2);
        public static Condition Bad { get; } = new(3);

        public static implicit operator string(Condition condition)
        {
            return condition.State switch
            {
                1 => "Good",
                2 => "With comments",
                3 => "Bad",
                _ => throw new InvalidOperationException("Invalid condition"),
            };
        }
    }
}
