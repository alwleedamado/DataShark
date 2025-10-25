using System.Reflection;
using System.Reflection.Emit;
using DataShark.DataGen.Models;

namespace DataShark.DataGen;

internal class TableBuilder(string typeName)
{
    public string TypeName { get; } = typeName;

    public TypeBuilder Create(Table table)
    {
        return CreateColumns(table);
    }

    private TypeBuilder CreateColumns(Table table)
    {
        var type = CustomAssembly.Instance.DefineType(TypeName, TypeAttributes.Public);
        foreach (var column in table.Columns)
        {
            PocoBuilder.DefineProperty(type, column.Name, column.ClrType);
        }
        return type;
    }
}
