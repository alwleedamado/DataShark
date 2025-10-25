using System.Globalization;
using CsvHelper;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Writers;

public class CsvOutputWriter
{
    public void Write(string dirPath, List<TableGenerationResult> result)
    {
        if (string.IsNullOrEmpty(dirPath))
            throw new ArgumentNullException(nameof(dirPath));
        if (!Directory.Exists(dirPath))
            throw new ArgumentException($"{dirPath} does not exists");
        var path = Path.Combine(dirPath, $"{result[0].TableName}.csv");
        var list = result.Select(x => x.Result.ContainedObject);
        using var output = new StreamWriter(path);
        using var csv = new CsvWriter(output, CultureInfo.InvariantCulture);
        csv.WriteRecords(list);
    }
}
