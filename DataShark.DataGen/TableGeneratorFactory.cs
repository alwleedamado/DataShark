using DataShark.DataGen.Models;

namespace DataShark.DataGen;

internal static class TableGeneratorFactory
{
    private static Dictionary<string, TableGenerator> TableGenerators { get; } = new();
    public static TableGenerator Create(Table table)
    {
        if (TableGenerators.TryGetValue(table.Name, out var tableGenerator)) { return tableGenerator; }

        var generator = new TableGenerator(table);
        TableGenerators.Add(table.Name, generator);
        return generator;
    }
}
