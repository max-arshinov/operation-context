using System.Reflection;

namespace OperationContext;

public static class Extensions
{
    public static void AddRequestContexts(this IServiceCollection services, Assembly assembly)
    {
            var ctxs = new List<Type>();

            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsTypeDefinition || type.IsAbstract || type.IsGenericType)
                {
                    continue;
                }

                var interfaces = type
                    .GetInterfaces()
                    .Where(x => x.IsGenericType)
                    .ToArray();

                foreach (var inf in interfaces)
                {
                    var gtd = inf.GetGenericTypeDefinition();

                    if (typeof(IRequestContext<>) == gtd)
                    {
                        ctxs.Add(type);
                    }
                }
            }

            foreach (var ctx in ctxs)
            {
                var inf = ctx
                    .GetInterfaces()
                    .First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IRequestContext<>));

                var requestType = inf.GenericTypeArguments[0];
                var funcType = typeof(Func<,>).MakeGenericType(requestType, ctx);

                var factoryType = typeof(RequestContextFactory<,>).MakeGenericType(requestType, ctx);

                services.AddScoped(factoryType);

                services.AddScoped(funcType, sp => ((dynamic) sp.GetService(factoryType)!).BuildFunc(sp));
            }
    }
}