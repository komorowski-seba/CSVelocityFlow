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
        // Inicjalizacja kontenera DI z ASP.NET Core
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

    // private void DisableAvaloniaDataAnnotationValidation()
    // {
    //     // Get an array of plugins to remove
    //     var dataValidationPluginsToRemove =
    //         BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();
    //
    //     // remove each entry found
    //     foreach (var plugin in dataValidationPluginsToRemove)
    //     {
    //         BindingPlugins.DataValidators.Remove(plugin);
    //     }
    // }
}

/*
// nawigacja 

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaWasmApp;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private object? _currentView;

    public MainViewModel()
    {
        // Widok startowy
        ShowTableView();
    }

    [RelayCommand]
    public void ShowTableView()
    {
        CurrentView = App.ServiceProvider.GetRequiredService<TableViewModel>();
    }

    [RelayCommand]
    public void ShowCheckboxView()
    {
        CurrentView = App.ServiceProvider.GetRequiredService<CheckboxViewModel>();
    }
}


// --------

// main view
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://microsoft.com networks"
             xmlns:local="using:AvaloniaWasmApp"
             x:Class="AvaloniaWasmApp.MainView"
             x:DataType="local:MainViewModel">

	<UserControl.DataTemplates>
		<!-- Powiązanie ViewModelu z Widokiem tabeli -->
		<DataTemplate DataType="{x:Type local:TableViewModel}">
			<local:TableView />
		</DataTemplate>
		<!-- Powiązanie ViewModelu z Widokiem checkboxów -->
		<DataTemplate DataType="{x:Type local:CheckboxViewModel}">
			<local:CheckboxView />
		</DataTemplate>
	</UserControl.DataTemplates>

	<DockPanel>
		<!-- Menu Górne (Wspólne dla wszystkich widoków) -->
		<StackPanel DockPanel.Dock="Top" Orientation="Horizontal" Background="#2b2b2b" Spacing="10" Padding="10">
			<Button Content="Widok Tabeli" 
			        Command="{Binding ShowTableViewCommand}" 
			        Padding="10,5" Background="#3c3c3c" Foreground="White"/>
			<Button Content="Widok Opcji (Checkbox)" 
			        Command="{Binding ShowCheckboxViewCommand}" 
			        Padding="10,5" Background="#3c3c3c" Foreground="White"/>
		</StackPanel>

		<!-- Dynamiczny Kontener Treści -->
		<ContentControl Content="{Binding CurrentView}" Margin="15"/>
	</DockPanel>
</UserControl>


// --------------------
// TableView.axaml

using System.Collections.ObjectModel;

namespace AvaloniaWasmApp;

public class SampleRow { public string Name { get; set; } = ""; public string Role { get; set; } = ""; }

public class TableViewModel
{
    public ObservableCollection<SampleRow> Items { get; } = [
        new() { Name = "Jan Kowalski", Role = "Administrator" },
        new() { Name = "Anna Nowak", Role = "Developer" },
        new() { Name = "Piotr Zieliński", Role = "Tester" }
    ];
}

//
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://microsoft.com"
             xmlns:local="using:AvaloniaWasmApp"
             x:Class="AvaloniaWasmApp.TableView"
             x:DataType="local:TableViewModel">
    <StackPanel Spacing="10">
        <TextBlock Text="Przegląd użytkowników (Widok Tabeli)" FontSize="18" FontWeight="Bold"/>
        <DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False" GridLinesVisibility="All" BorderThickness="1" BorderBrush="Gray">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Imię i Nazwisko" Binding="{Binding Name}" Width="*" />
                <DataGridTextColumn Header="Rola" Binding="{Binding Role}" Width="*" />
            </DataGrid.Columns>
        </DataGrid>
    </StackPanel>
</UserControl>


// --------

heckboxView.axaml

using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaWasmApp;

public partial class CheckboxViewModel : ObservableObject
{
    [ObservableProperty] private bool _isNotificationsEnabled = true;
    [ObservableProperty] private bool _isDarkModeEnabled = false;
    [ObservableProperty] private bool _isTelemetryEnabled = true;
}

//
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://microsoft.com"
             xmlns:local="using:AvaloniaWasmApp"
             x:Class="AvaloniaWasmApp.CheckboxView"
             x:DataType="local:CheckboxViewModel">
	<StackPanel Spacing="15">
		<TextBlock Text="Ustawienia Aplikacji (Widok Checkbox)" FontSize="18" FontWeight="Bold"/>
		
		<CheckBox Content="Włącz powiadomienia push" IsChecked="{Binding IsNotificationsEnabled}"/>
		<CheckBox Content="Używaj trybu ciemnego (Dark Mode)" IsChecked="{Binding IsDarkModeEnabled}"/>
		<CheckBox Content="Zezwól na wysyłanie danych analitycznych" IsChecked="{Binding IsTelemetryEnabled}"/>
		
		<TextBlock Text="Stan opcji w systemie:" Margin="0,15,0,0" FontWeight="SemiBold"/>
		<StackPanel Orientation="Horizontal" Spacing="5">
			<TextBlock Text="Powiadomienia:"/>
			<TextBlock Text="{Binding IsNotificationsEnabled}"/>
		</StackPanel>
	</StackPanel>
</UserControl>




*/