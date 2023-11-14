using MemoryClient.Components;
using MemoryClient.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
namespace MemoryClient;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.AddEyEClientDependencies();
        var services = builder.Services;
        services.AddScoped<UserChecker>();
        var host = builder.Build();
        await host.AddEyEClientHostDependenciesAsync();
        await host.RunAsync();
    }
}

