namespace OperationContext;

public class RequestContextFactory<TRequest, TContext>
    where TRequest : class
    where TContext : RequestContextBase<TRequest>
{
    public Func<TRequest, TContext?> BuildFunc(IServiceProvider sp)
    {
        return x => Build(sp, x);
    }

    public TContext? Build(IServiceProvider sp, TRequest? request)
    {
        if (request == null)
        {
            return null;
        }

        var constructor = Cache<TRequest, TContext>.Constructors.GetOrAdd(typeof(TContext), GetConstructor);
        return constructor(request);
    }

    private Func<TRequest, TContext> GetConstructor(Type type)
    {
        throw new NotImplementedException();
    }
}