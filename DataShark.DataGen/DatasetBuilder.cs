using DataShark.DataGen.Models;

namespace DataShark.DataGen;

public class DatasetBuilder
{
    private static readonly Dictionary<string, TypeProxy> DatasetsCache = new();
    private readonly Dictionary<string, TypeProxy> _tablesCache = new();

    public TypeProxy BuildDataset(Dataset dataset)
    {
        if (DatasetsCache.TryGetValue(dataset.Name, out var value))
        {
            return value;
        }
        var builder = CustomAssembly.Instance.DefineType(dataset.Name, System.Reflection.TypeAttributes.Public);
        foreach (var table in dataset.Tables)
        {
            var tableBuilder = new TableBuilder(table.Name);
            var tableType = tableBuilder.Create(table);
            Type tablePropType = tableType.CreateType();
            _tablesCache.Add(table.Name, new TypeProxy(table.Name, tablePropType));
            PocoBuilder.DefineProperty(builder, tableBuilder.TypeName, tablePropType);
        }
        var createdType = new TypeProxy(dataset.Name, builder.CreateType());
        DatasetsCache[dataset.Name] = createdType;
        return createdType;
    }

    public TypeProxy BuildSingleTable(string datasetName, Table table)
    {
        if (_tablesCache.TryGetValue(table.Name, out var value)) { return value; }

        var tableBuilder = new TableBuilder(table.Name);
        var type = tableBuilder.Create(table);
        var concreteType = new TypeProxy(table.Name, type.CreateType());
        _tablesCache.Add(table.Name, concreteType);
        return concreteType;
    }
}
