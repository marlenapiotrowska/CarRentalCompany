namespace CarRentalCompany.Frontend.Domain.ValueObjects
{
    public sealed class ExecutionResultGeneric<TResult> : ExecutionResult
    {
        private ExecutionResultGeneric(
            bool isSuccess,
            string message,
            TResult payload)
            : base(isSuccess, message)
        {
            Payload = payload;
        }

        public TResult Payload { get; }

        public static ExecutionResultGeneric<TResult> CreateSuccessful(TResult payload)
        {
            return new ExecutionResultGeneric<TResult>(true, null, payload);
        }

        public static ExecutionResultGeneric<TResult> CreateFailed(string message)
        {
            return new ExecutionResultGeneric<TResult>(false, message, default);
        }
    }
}
