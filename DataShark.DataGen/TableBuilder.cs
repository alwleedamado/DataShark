using System.Reflection;
using DataShark.DataGen.Models;

namespace DataShark.DataGen;

internal static class TableBuilder
{
    public static TypeProxy Build(Table table)
    {
        var type = CustomAssembly.Instance.DefineType(table.Name, TypeAttributes.Public);
        foreach (var column in table.Columns)
        {
            PocoBuilder.DefineProperty(type, column.Name, column.ClrType);
        }

        return new TypeProxy(table.Name, type.CreateType());
    }
}
