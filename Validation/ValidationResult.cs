namespace Validation
{
    public class ValidationResult
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }
        public string ErrorProperty { get; }

        public static readonly ValidationResult Success = new(true);

        public static ValidationResult Error(string message, string property) => new(message, property);

        private ValidationResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        private ValidationResult(string errorMessage, string errorProperty)
            : this(false)
        {
            ErrorMessage = errorMessage;
            ErrorProperty = errorProperty;
        }
    }
}
