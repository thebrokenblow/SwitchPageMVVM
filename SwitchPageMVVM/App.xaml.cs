using Microsoft.Extensions.DependencyInjection;
using SwitchPageMVVM.Core;
using SwitchPageMVVM.Services;
using SwitchPageMVVM.ViewModel;
using System.Windows;

namespace SwitchPageMVVM;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider serviceProvider;
    public App()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton(provider => new MainWindow
        {
            DataContext = provider.GetService<MainViewModel>()
        });

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<AboutViewModel>();
        services.AddSingleton<MenuViewModel>();
        services.AddSingleton<INavigationService, NavigationService>();


        services.AddSingleton<Func<Type, BaseViewModel>>(
            serviceProvider => 
            viewModelType => 
                (BaseViewModel)serviceProvider.GetRequiredService(viewModelType));

        serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }
}
