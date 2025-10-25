namespace DataShark.DataGen.Models;

internal class DatasetGenerator(string name)
{
    public string Name { get; } = name;
    public Dictionary<string, TableGenerator> TableGenerators { get; } = new();
}