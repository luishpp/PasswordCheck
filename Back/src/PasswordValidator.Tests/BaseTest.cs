using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PasswordValidator.Infrastructure.Configuration;
using PasswordValidator.Infrastructure.Factories;

namespace PasswordValidator.Tests;

public class BaseTest
{
    public BaseTest()
    {
        TestHost = CreateHostBuilder().Build();
        Task.Run(() => TestHost.RunAsync());
    }

    public IHost TestHost { get; }

    public static IHostBuilder CreateHostBuilder(string[] args = null) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true);
                config.AddEnvironmentVariables();

                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();
                services.Configure<RegexRule>(hostContext.Configuration.GetSection("RegexRule"));
                services.Configure<RetryRules>(hostContext.Configuration.GetSection("RetryRules"));
                services.AddScoped<IPasswordServiceFactory, PasswordServiceFactory>();                    
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
            });
}