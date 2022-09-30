namespace OperationContext;

public abstract class RequestContextBase<T> : IRequestContext<T>
    where T : class
{
    protected RequestContextBase(T request)
    {
        Request = request;
    }

    public T Request { get; }
}