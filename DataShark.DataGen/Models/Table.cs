namespace DataShark.DataGen.Models;

public class Table(string name)
{
    public string Name { get; } = name;
    private readonly List<Column> _columns = [];
    public IReadOnlyCollection<Column> Columns => _columns.AsReadOnly();

    public void AddColumn(Column column) { _columns.Add(column); }
    public void RemoveColumn(Column column) { _columns.Remove(column); }
}
