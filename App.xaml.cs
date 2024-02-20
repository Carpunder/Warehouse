using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Integration.Contracts;
using WpfApp1.Integration.Service;
using WpfApp1.Warehouse.Data;
using WpfApp1.Warehouse.Data.Contracts;
using WpfApp1.Warehouse.Data.Services;

namespace WpfApp1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }
    
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<WarehouseDbContext>();
            
        services.AddSingleton<MainWindow>();

        services.AddScoped<IImportService, ImportService>();
        services.AddScoped<IMarkingService, MarkingService>();
    }
    
    private void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}