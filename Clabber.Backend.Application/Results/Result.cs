namespace Clabber.Backend.Application.Results
{
    /// <summary>
    /// Represents a result of an operation
    /// </summary>
    public class Result
    {
        public Result(bool isSuccess, OperationStatusCode statusCode)
        {
            this.IsSuccess = isSuccess;
            this.StatusCode = statusCode;
        }
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
        public List<string> Messages { get; set; } = [];
        /// <summary>
        /// Gets or sets the result code that indicates the outcome of the operation.
        /// </summary>
        public OperationStatusCode StatusCode { get; set; }
        public static Result Success() => new Result(true, OperationStatusCode.SUCCESS);
        public static Result Failed() => new Result(false, "Operation was a failure.", OperationStatusCode.FAILED);
        public static Result Failed(string message) => new Result(false, message, OperationStatusCode.FAILED);
        public static Result Failed(List<string> messages) => new Result(false, messages, OperationStatusCode.FAILED);
        public static Result ValidationFailed() => new Result(false, "Validation failed.", OperationStatusCode.VALIDATION_FAILED);
        public static Result ValidationFailed(string message) => new Result(false, message, OperationStatusCode.VALIDATION_FAILED);
        public static Result ValidationFailed(List<string> messages) => new Result(false, messages, OperationStatusCode.VALIDATION_FAILED);
        public static Result NotFound() => new Result(false, "Not found.", OperationStatusCode.NOT_FOUND);

    }
    /// <summary>
    /// Represents a result of an operation that returns a value of type T
    /// </summary>
    public class Result<T> : Result
    {
        public Result(bool isSuccess, OperationStatusCode statusCode, T? value) : base(isSuccess, statusCode)
        {
            this.Value = value;
        }
        public Result(bool isSuccess, List<string> messages, OperationStatusCode statusCode, T? value) : base(isSuccess, messages, statusCode)
        {
            this.Value = value;
        }
        public Result(bool isSuccess, string message, OperationStatusCode statusCode, T? value) : base(isSuccess, message, statusCode)
        {
            this.Value = value;
        }

        public T? Value { get; set; }
        public static Result<T> Success(T value) => new Result<T>(true, OperationStatusCode.SUCCESS, value);
        public new static Result<T> Failed() => new Result<T>(false, "Operation was a failure.", OperationStatusCode.FAILED, default);
        public new static Result<T> Failed(string message) => new Result<T>(false, message, OperationStatusCode.FAILED, default);
        public new static Result<T> Failed(List<string> messages) => new Result<T>(false, messages, OperationStatusCode.FAILED, default);
        public new static Result<T> ValidationFailed() => new Result<T>(false, "Validation failed.", OperationStatusCode.VALIDATION_FAILED, default);
        public new static Result<T> ValidationFailed(string message) => new Result<T>(false, message, OperationStatusCode.VALIDATION_FAILED, default);
        public new static Result<T> ValidationFailed(List<string> messages) => new Result<T>(false, messages, OperationStatusCode.VALIDATION_FAILED, default);
        public new static Result<T> NotFound() => new Result<T>(false, "Not found.", OperationStatusCode.NOT_FOUND, default);
    }
}
