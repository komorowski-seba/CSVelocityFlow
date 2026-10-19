using System.ComponentModel;

namespace CsVelocityFlow.Core.Interfaces;

public interface INavigationService : INotifyPropertyChanged
{
    object? CurrentView { get; }
    void NavigateTo<TViewModel>() where TViewModel : class;
}