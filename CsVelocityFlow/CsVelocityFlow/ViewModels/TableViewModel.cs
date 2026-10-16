using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CsVelocityFlow.ViewModels;

public class SampleRow
{
    public string Name { get; set; } = ""; 
    public string Role { get; set; } = "";
}


public partial class TableViewModel : ObservableObject 
{
    public ObservableCollection<SampleRow> Items { get; } = [
        new() { Name = "Jan Kowalski", Role = "Administrator" },
        new() { Name = "Anna Nowak", Role = "Developer" },
        new() { Name = "Piotr Zieliński", Role = "Tester" }
    ];

}