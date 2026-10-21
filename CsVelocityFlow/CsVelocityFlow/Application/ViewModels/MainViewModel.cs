using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace CsVelocityFlow.Application.ViewModels;

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
        CurrentView = ServiceProviderServiceExtensions.GetRequiredService<TableViewModel>(App.ServiceProvider);
    }

    [RelayCommand]
    public void ShowCheckboxView()
    {
        CurrentView = ServiceProviderServiceExtensions.GetRequiredService<CheckboxViewModel>(App.ServiceProvider);
    }
}

/*

    private readonly INavigationService _navigationService;


    // Pobieramy CurrentView bezpośrednio z serwisu nawigacji
    public object? CurrentView => _navigationService.CurrentView;


    public ICommand ShowTableViewCommand { get; }
    public ICommand ShowCheckboxViewCommand { get; }


    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;


        // Podpinamy zdarzenie zmiany widoku z serwisu do ViewModelu, by powiadomić UI w Avalonia
        _navigationService.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(INavigationService.CurrentView))
            {
                OnPropertyChanged(nameof(CurrentView));
            }
        };


        // Definiujemy akcje komend za pomocą generycznej metody nawigacji
        ShowTableViewCommand = new RelayCommand(() => _navigationService.NavigateTo<TableViewModel>());
        ShowCheckboxViewCommand = new RelayCommand(() => _navigationService.NavigateTo<CheckboxViewModel>());


        // Ustawienie widoku startowego (opcjonalnie)
        _navigationService.NavigateTo<TableViewModel>();
    }



*/