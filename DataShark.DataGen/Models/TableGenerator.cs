using System.Reflection;
using Bogus;

namespace DataShark.DataGen.Models;

internal class TableGenerator
{
    private readonly TypeProxy _tableType;
    public string Name { get; }
    public Dictionary<string, Generator> ColumnGenerators { get; } = new();

    private object? _faker;
    private MethodInfo? _fakerGenerateFn;
    public TableGenerator(Table table, TypeProxy tableType)
    {
        _tableType = tableType;
        Name = table.Name;
        foreach (var column in table.Columns)
        {
            ColumnGenerators[column.Name] = column.Generator;
        }

        Initialize(tableType);
    }

    private void Initialize(TypeProxy tableType)
    {
        var fakerType = typeof(Faker<>);
        var genericType = fakerType.MakeGenericType(tableType.Type);
        _faker = Activator.CreateInstance(genericType);
        var ruleFor = typeof(TableGenerator)
            .GetMethod(nameof(RuleFor), BindingFlags.Instance | BindingFlags.NonPublic) ??
                      throw new Exception("Couldn't invoke RuleRor method");
        foreach (var column in _tableType.GetProperties())
        {
            var genericFn = ruleFor.MakeGenericMethod(_tableType.Type, column.PropertyType);
            _faker = genericFn.Invoke(this,[_faker, column.Name, ColumnGenerators[column.Name]]);
        }

        _fakerGenerateFn = typeof(Faker<>).GetMethod("Generate", BindingFlags.Instance | BindingFlags.Public);
    }

    private Faker<T> RuleFor<T, TPropertyType>(Faker<T> faker, string propName, Generator generator) where T : class where TPropertyType : class
    {
        return faker.RuleFor(propName, generator.Generate<T, TPropertyType>());
    }
    public IEnumerable<TableGenerationResult> Generate(int? sampleCount = 1)
    {
        for (var i = 0; i < sampleCount; i++)
        {
            var result = _fakerGenerateFn?.Invoke(_faker, null);
            yield return new TableGenerationResult(Name, new ObjectProxy(result));
        }
    }
}
