using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace CsVelocityFlow.Application.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase? _currentView;

    public MainViewModel()
    {
        ShowTableView();
    }    
    
    [RelayCommand]
    private void ShowTableView()
    {
        CurrentView = App.ServiceProvider.GetRequiredService<TableViewModel>();
    }

    [RelayCommand]
    private void ShowCheckboxView()
    {
        CurrentView = App.ServiceProvider.GetRequiredService<CheckboxViewModel>();
    }
}