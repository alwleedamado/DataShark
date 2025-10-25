using DataShark.DataGen.Models;

namespace DataShark.DataGen;

public class GenerationContext
{
    public IEnumerable<IEnumerable<TableGenerationResult>> GenerateWholeDataset(Dataset dataset, int? sampleCount = 1)
    {
        var datasetProxy = DatasetBuilder.Build(dataset);
        var tables = datasetProxy.GetProperties().ToArray();
        var generators = new List<TableGenerator>(capacity: tables.Length);
        generators.AddRange(from table in dataset.Tables
            let tableType = TableBuilder.Build(table)
            select new TableGenerator(table, tableType));

        var ret = generators
            .AsParallel()
            .Select(gen => gen.Generate(sampleCount))
            .AsEnumerable();
        return ret;
    }

    public IEnumerable<TableGenerationResult> GenerateSingleTable(Table table, int? sampleCount = 1)
    {
        var tableType = TableBuilder.Build(table);
        var generator = new TableGenerator(table, tableType);
        return generator.Generate(sampleCount);
    }
}
