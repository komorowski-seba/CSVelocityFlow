using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace CsVelocityFlow.Application.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase? _currentView;
    [ObservableProperty] private bool _isMenuOpen;
    private TableViewModel _tableViewModel;
    private CheckboxViewModel _checkboxViewModel;

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