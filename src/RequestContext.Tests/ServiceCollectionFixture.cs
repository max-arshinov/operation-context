using Microsoft.Extensions.DependencyInjection;

namespace RequestContext.Tests;

public class ServiceCollectionFixture
{
    private readonly IServiceCollection _serviceCollection = new ServiceCollection();

    public IServiceProvider ServiceProvider { get; }
    
    public ServiceCollectionFixture()
    {
        ServiceProvider = _serviceCollection.BuildServiceProvider();
    }
}