using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CsVelocityFlow.Application.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase? _currentView;
    [ObservableProperty] private bool _isMenuOpen;
    private readonly TableViewModel _tableViewModel;
    private readonly CheckboxViewModel _checkboxViewModel;

    public MainViewModel(Lazy<TableViewModel> tableViewModel, Lazy<CheckboxViewModel> checkboxViewModel)
    {
        _tableViewModel = tableViewModel.Value;
        _checkboxViewModel = checkboxViewModel.Value;
        ShowTableView();
    }    
    
    [RelayCommand]
    private void ShowTableView()
    {
        CurrentView = _tableViewModel;
    }

    [RelayCommand]
    private void ShowCheckboxView()
    {
        CurrentView = _checkboxViewModel;
    }
}