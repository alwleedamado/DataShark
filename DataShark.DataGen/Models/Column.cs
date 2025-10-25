// ReSharper disable ClassNeverInstantiated.Global
namespace DataShark.DataGen.Models;

public class Column
{
    public required string Name { get; set; }
    public required ClrType ClrType { get; set; }
    public required GeneratorDescriptor GeneratorDescriptor { get; set; }
}