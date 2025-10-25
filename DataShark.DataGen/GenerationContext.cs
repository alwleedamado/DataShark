using System.Reflection;
using Bogus;
using DataShark.DataGen.Models;

namespace DataShark.DataGen;

public class GenerationContext
{
    private static readonly Dictionary<string, DatasetBuilder> DatasetBuilderCache = new();
    public object GenerateWholeDataset(Dataset dataset)
    {
        var builder = GetDatasetBuilder(dataset.Name);
        var datasetProxy = builder.BuildDataset(dataset);
        var datasetGenerator = DatasetGeneratorFactory.Create(dataset);
        var tables = datasetProxy.GetProperties().ToList();
        var result = new DatasetGenerationResult(dataset.Name);

        foreach (var table in tables)
        {
            var tableGenerator = datasetGenerator.TableGenerators[table.Name];
            var creatorMethod = typeof(GenerationContext).GetMethod(nameof(RuleForTable), BindingFlags.Instance | BindingFlags.NonPublic);
            var methodInfo = creatorMethod?.MakeGenericMethod( [table.PropertyType]);
            var faker = methodInfo?.Invoke(this, [tableGenerator, table.PropertyType]);
            var genMethod = faker?.GetType().GetMethod("Generate", [typeof(string)]);
            var r = genMethod?.Invoke(faker, [null])
                    ?? throw new Exception($"Failed to generate data for {table.Name}");
            result.Tables.Add(new TableGenerationResult(table.Name, new ObjectProxy(r)));
        }
        return result;
    }
    public IEnumerable<object?> GenerateTable(Table table, int sampleCount = 1)
    {
        var builder = new TableBuilder(table.Name);
        var typeBuilder = builder.Create(table);
        var generator = TableGeneratorFactory.Create(table);
        var ruleForTable = typeof(GenerationContext).GetMethod(nameof(RuleForTable), BindingFlags.Instance | BindingFlags.NonPublic);
        var genericMd = ruleForTable?.MakeGenericMethod([typeBuilder.CreateType()]);
        var faker = genericMd?.Invoke(this, [generator, typeBuilder.CreateType()]);
        var fakerGenerateMd = faker?.GetType().GetMethod("Generate", [typeof(string)]);
        for (var i = 0; i < sampleCount; i++)
        {
            yield return fakerGenerateMd?.Invoke(faker, [null]);
        }
    }

    private static Faker<T> RuleFor<T, TPropertyType>(Faker<T> faker, string propName, Generator generator) where T : class where TPropertyType : class
    {
        return faker.RuleFor(propName, generator.Generate<T, TPropertyType>());
    }
    private Faker<T>? RuleForTable<T>(TableGenerator tableGenerator, Type tableType) where T : class
    {
        var columns = tableType.GetProperties();
        Faker<T>? faker = new();
        var ruleForInfo = typeof(GenerationContext).GetMethod(nameof(RuleFor), BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var column in columns)
        {
            var columnName = column.Name;
            var generator = tableGenerator.ColumnGenerators[columnName];
            var generic = ruleForInfo?.MakeGenericMethod(typeof(T), column.PropertyType);
            faker = (Faker<T>?)generic?.Invoke(this, [faker!, columnName, generator]);
        }
        return faker;
    }
    private static DatasetBuilder GetDatasetBuilder(string name)
    {
        if (DatasetBuilderCache.TryGetValue(name, out var dataset))
            return dataset;

        var builder = new DatasetBuilder();
        DatasetBuilderCache.Add(name, builder);
        return builder;
    }
}
