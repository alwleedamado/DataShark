using DataShark.DataGen.Models;

namespace DataShark.DataGen;

public static class DatasetBuilder
{
    private static readonly Dictionary<string, TypeProxy> DatasetsCache = new();

    public static TypeProxy Build(Dataset dataset)
    {
        if (DatasetsCache.TryGetValue(dataset.Name, out var value))
        {
            return value;
        }
        var builder = CustomAssembly.Instance.DefineType(dataset.Name, System.Reflection.TypeAttributes.Public);
        foreach (var table in dataset.Tables)
        {
            var tableType = TableBuilder.Build(table);
            PocoBuilder.DefineProperty(builder, tableType.TypeName, tableType.Type);
        }
        var createdType = new TypeProxy(dataset.Name, builder.CreateType());
        DatasetsCache[dataset.Name] = createdType;
        return createdType;
    }
}
