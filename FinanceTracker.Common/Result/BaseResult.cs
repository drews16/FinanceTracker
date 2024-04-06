namespace FinanceTracker.Common.Result
{
    public class BaseResult
    {
        public virtual bool IsSuccess => !ErrorMessages.Any();
        public IEnumerable<string> ErrorMessages { get; init; } = Enumerable.Empty<string>();
    }

    public class BaseResult<T> : BaseResult
    {
        public virtual bool IsSuccess => Result != null;
        public T? Result { get; init; }
    }
}