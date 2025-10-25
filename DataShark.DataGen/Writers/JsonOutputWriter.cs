using System.Text.Json;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Writers;

public class JsonOutputWriter(JsonSerializerOptions? options = null)
{
    private readonly JsonSerializerOptions _options = options ?? new JsonSerializerOptions();

    public void Write(string dirPath,List<TableGenerationResult> result)
    {
        if (string.IsNullOrEmpty(dirPath))
            throw new ArgumentNullException(nameof(dirPath));
        if (!Directory.Exists(dirPath))
            throw new ArgumentException($"{dirPath} does not exists");
        
        var path = Path.Combine(dirPath, $"{result[0].TableName}.json");
        string json;
        var list = result.Select(x => x.Result.ContainedObject).ToList();
        json = result.Count == 1 ?
            JsonSerializer.Serialize(list[0], _options)
            : JsonSerializer.Serialize(list,_options);
        using var writer = new StreamWriter(path);
        writer.Write(json.AsSpan());
    }
}
