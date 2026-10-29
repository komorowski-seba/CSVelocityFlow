using CommunityToolkit.Mvvm.ComponentModel;

namespace CsVelocityFlow.Application.ViewModels;

public partial class CheckboxViewModel : ViewModelBase 
{
    [ObservableProperty] private bool _isNotificationsEnabled = true;
    [ObservableProperty] private bool _isDarkModeEnabled = false;
    [ObservableProperty] private bool _isTelemetryEnabled = true;
}