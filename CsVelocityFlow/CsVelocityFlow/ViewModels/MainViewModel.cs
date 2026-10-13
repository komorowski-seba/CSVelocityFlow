using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace CsVelocityFlow.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
    [ObservableProperty] private object? _currentView;

    public MainViewModel()
    {
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