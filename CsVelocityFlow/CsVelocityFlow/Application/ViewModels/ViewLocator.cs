using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CsVelocityFlow.Application.Views;
using TableView = CsVelocityFlow.Application.Views.TableView;

namespace CsVelocityFlow.Application.ViewModels;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        return data switch
        {
            MainViewModel => new MainView(),
            TableViewModel => new TableView(),
            CheckboxViewModel => new CheckboxView(),
            
            _ => new TextBlock { Text = $"Nie znaleziono widoku dla: {data.GetType().Name}" }
        };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase; 
    }
}