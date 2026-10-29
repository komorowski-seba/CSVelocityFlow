using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CsVelocityFlow.Core.Services;

public class NavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private object? _currentView;

    public event PropertyChangedEventHandler? PropertyChanged;


    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public object? CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public void NavigateTo<TViewModel>() where TViewModel : class
    {
        // var viewModel = _serviceProvider.GetService(typeof(TViewModel));
        // CurrentView = viewModel;
    }


    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}