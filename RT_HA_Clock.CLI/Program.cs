using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using RT_HA_Clock.CLI;
using RT_HA_Clock.CLI.Interfaces;
using RT_HA_Clock.CLI.IO;
using RT_HA_Clock.LIB.Interfaces.Services;
using RT_HA_Clock.LIB.Interfaces.Services.IO;
using RT_HA_Clock.Logic.Services;

class Program
{
    public static Task<int> Main(string[] args) =>
        CommandLineApplication.ExecuteAsync<Program>(args);

    public async Task<int> OnExecuteAsync(CancellationToken cancellationToken)
    {
        var services = new ServiceCollection();

        services.AddScoped<ClockCli>();
        services.AddScoped<IClockCli>(implementationFactory: service => service.GetRequiredService<ClockCli>());
        services.AddScoped<IClockViewService>(implementationFactory: service => service.GetRequiredService<ClockCli>());
        services.AddScoped<IInputValidationService, InputValidationService>();
        services.AddScoped<IAnalogClockService, AnalogClockService>();
        services.AddScoped<ConsoleLogger>();
        services.AddScoped<IReader>(implementationFactory: service => service.GetRequiredService<ConsoleLogger>());
        services.AddScoped<IWriter>(implementationFactory: service => service.GetRequiredService<ConsoleLogger>());

        await using ServiceProvider serviceProvider = services.BuildServiceProvider(validateScopes: true);
        using (IServiceScope scope = serviceProvider.CreateScope())
        {
            var clockConsole = scope.ServiceProvider.GetRequiredService<IClockCli>();
            clockConsole.Run();
        }

        return Environment.ExitCode;
    }
}