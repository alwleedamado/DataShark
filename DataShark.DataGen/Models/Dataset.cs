namespace DataShark.DataGen.Models;

public class Dataset(string name)
{
    public Guid Id { get; set; }
    public string Name { get; set; } = name;
    public List<Table> Tables { get; } = [];
}
