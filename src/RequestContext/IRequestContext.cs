namespace OperationContext;

// assembly-scanning optimization
internal interface IRequestContext<out T>
{
    T Request { get; }
}