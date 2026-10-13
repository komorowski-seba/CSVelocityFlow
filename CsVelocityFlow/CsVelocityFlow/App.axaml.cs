using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using CsVelocityFlow.ViewModels;
using CsVelocityFlow.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CsVelocityFlow;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();

        // Rejestracja ViewModeli (Main zarządzający oraz widoki podrzędne)
        // services.AddSingleton<MainViewModel>();
        // services.AddTransient<TableViewModel>();
        // services.AddTransient<CheckboxViewModel>();

        ServiceProvider = services.BuildServiceProvider();        
        
        if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                // DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}