using System.Collections.Concurrent;

namespace OperationContext;

internal static class Cache<TRequest, TContext> 
    where TRequest : notnull
{
    internal static readonly ConcurrentDictionary<Type, Func<TRequest, TContext>> Constructors = new();
    
}