namespace DataShark.DataGen.Models;

public class ConcreteType(string name, Type type)
{
    public string Name { get; } = name;
    public Type Type { get; } = type;
}