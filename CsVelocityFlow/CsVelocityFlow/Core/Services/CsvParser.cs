using System.Threading.Tasks;
using Avalonia.Controls;
using CsVelocityFlow.Core.Interfaces;
using Avalonia.Platform.Storage;
using CsvHelper;

namespace CsVelocityFlow.Core.Services;

public class CsvParser: IParser
{

    private async Task OpenAndProcessCsvAsync()
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel is null) return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Wybierz plik CSV",
            AllowMultiple = false
        });

        if (files.Count >= 1)
        {
            await using var stream = await files[0].OpenReadAsync();
            using var reader = CsvReader.Create(stream); 

            int rowCount = 0;
            while (reader.Read())
            {
                var id = reader.GetString(0);
                var name = reader.GetString("Name");
                
                // ...

                if (++rowCount % 500 == 0)
                {
                    await Task.Delay(1);
                }
            }
        }
    }
}