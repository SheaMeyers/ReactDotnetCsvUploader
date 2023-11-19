using CsvHelper;
using System.Globalization;


namespace CsvUploader.Converters;

public static class FileToEntitiesConverter
{
    public static IEnumerable<T> GetEntities<T>(IFormFile csvFile)
    {
        using var reader = new StreamReader(csvFile.OpenReadStream());
        using var csvr = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csvr.GetRecords<T>();
    }
}
