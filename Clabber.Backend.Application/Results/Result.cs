namespace Clabber.Backend.Application.Results
{
    /// <summary>
    /// Represents a result of an operation
    /// </summary>
    public class Result
    {
        public Result(bool isSuccess, List<string> messages, OperationStatusCode statusCode)
        {
            this.IsSuccess = isSuccess;
            this.Messages = messages;
            this.StatusCode = statusCode;
        }
        public Result(bool isSuccess, string message, OperationStatusCode statusCode)
        {
            this.IsSuccess = isSuccess;
            this.Messages = new List<string>() { message };
            this.StatusCode = statusCode;
        }
        /// <summary>
        /// Gets or sets a value indicating whether the operation completed successfully.
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Gets or sets the collection of messages associated with the current instance.
        /// </summary>
        public List<string> Messages { get; set; }
        /// <summary>
        /// Gets or sets the result code that indicates the outcome of the operation.
        /// </summary>
        public OperationStatusCode StatusCode { get; set; }
    }
    /// <summary>
    /// Represents a result of an operation that returns a value of type T
    /// </summary>
    public class Result<T> : Result
    {
        public Result(bool isSuccess, List<string> messages, OperationStatusCode statusCode, T? value) : base(isSuccess, messages, statusCode)
        {
            this.Value = value;
        }
        public Result(bool isSuccess, string message, OperationStatusCode statusCode, T? value) : base(isSuccess, message, statusCode)
        {
            this.Value = value;
        }
        /// <summary>
        /// Gets or sets a value associated with the result of an operation.
        /// </summary>
        public T? Value { get; set; }
    }
}
