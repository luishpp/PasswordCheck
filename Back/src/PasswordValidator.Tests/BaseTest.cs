using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PasswordValidator.Application.Contracts;
using PasswordValidator.Application.Services;
using PasswordValidator.Infrastructure.Configuration;

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
                services.Configure<RegexConfig>(hostContext.Configuration.GetSection("RegexConfiguration"));
                services.AddScoped<IPasswordService, PasswordService>();             
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
            });
}