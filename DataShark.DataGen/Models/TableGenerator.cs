namespace DataShark.DataGen.Models;

internal class TableGenerator(string tableName)
{
    public string Name { get; } = tableName;
    public Dictionary<string, Generator> ColumnGenerators { get; } = new();
}