using DataShark.DataGen.Models;

namespace DataShark.DataGen;

internal static class TableGeneratorFactory
{
    private static Dictionary<string, TableGenerator> TableGenerators { get; } = new();
    public static TableGenerator Create(Table table)
    {
        if (TableGenerators.TryGetValue(table.Name, out TableGenerator? tableGenerator)) { return tableGenerator; }

        var generator = new TableGenerator(table.Name);
        TableGenerators.Add(table.Name, generator);
        foreach (Column column in table.Columns)
        {
            Generator columnGenerator = BuildColumnGenerator(column.GeneratorDescriptor)
                                        ?? throw new Exception("Failed to generate generator implementation");
            generator.ColumnGenerators.Add(column.Name, columnGenerator);
        }
        return generator;
    }
    private static Generator? BuildColumnGenerator(GeneratorDescriptor descriptor)
    {
        var currentAssembly = typeof(DatasetGeneratorFactory).Assembly
                              ?? throw new Exception("Couldn't Get a handle to the current assembly");
        var generators = currentAssembly.GetTypes();
        var generator = generators.Where(x => x.BaseType == typeof(Generator)).Single(x =>
        {
            var genName = x.Name.Replace("Generator", "").ToLower().Trim();
            return genName == descriptor.GeneratorName.ToLower().Trim();
        });
        var obj = Activator.CreateInstance(generator, descriptor) as Generator;
        return obj;
    }

}
