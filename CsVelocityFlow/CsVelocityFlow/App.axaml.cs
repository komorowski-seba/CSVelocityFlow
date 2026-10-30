using System;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CsVelocityFlow.Application.ViewModels;
using CsVelocityFlow.Application.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CsVelocityFlow;

public class App : Avalonia.Application
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();

        services.AddSingleton<MainViewModel>();
        services.AddTransient<TableViewModel>();
        services.AddTransient<CheckboxViewModel>();

        ServiceProvider = services.BuildServiceProvider();
        if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}