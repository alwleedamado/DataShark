using System.Text.Json;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Writers;

public class JsonOutputWriter(JsonSerializerOptions? options = null)
{
    private readonly JsonSerializerOptions _options = options ?? new JsonSerializerOptions();

    public void Write(string dirPath, TableGenerationResult result)
    {
        if (string.IsNullOrEmpty(dirPath))
            throw new ArgumentNullException(nameof(dirPath));
        if (!Directory.Exists(dirPath))
            throw new ArgumentException($"{dirPath} does not exists");
        
        ReadOnlySpan<char> json = JsonSerializer.Serialize(result.Result.ContainedObject, _options);
        var path = Path.Combine(dirPath, $"{result.TableName}.json");
        File.WriteAllText(path, json);
    }
}
