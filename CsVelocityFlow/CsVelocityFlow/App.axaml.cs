using System;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CsVelocityFlow.Application.ViewModels;
using CsVelocityFlow.Application.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CsVelocityFlow;

public class App : Avalonia.Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<TableViewModel>(sp => new Lazy<TableViewModel>(() => sp.GetRequiredService<TableViewModel>()));
        services.AddSingleton<CheckboxViewModel>(sp => new Lazy<CheckboxViewModel>(() => sp.GetRequiredService<CheckboxViewModel>()));

        var serviceProvider = services.BuildServiceProvider();
        if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}