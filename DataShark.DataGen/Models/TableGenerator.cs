namespace DataShark.DataGen.Models;

internal class TableGenerator
{
    public string Name { get; }
    public Dictionary<string, Generator> ColumnGenerators { get; } = new();

    public TableGenerator(Table table)
    {
        Name = table.Name;
        foreach (var column in table.Columns)
        {
            ColumnGenerators[column.Name] = column.Generator;
        }
    }
}
