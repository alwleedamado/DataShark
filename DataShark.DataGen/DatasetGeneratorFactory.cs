using DataShark.DataGen.Models;

namespace DataShark.DataGen;

internal static class DatasetGeneratorFactory
{
    public static DatasetGenerator Create(Dataset dataset)
    {
        DatasetGenerator datasetGenerator = new(dataset.Name);
        foreach (var table in dataset.Tables)
        {
            var tableGenerator = TableGeneratorFactory.Create(table);
            datasetGenerator.TableGenerators.Add(table.Name, tableGenerator);
        }
        return datasetGenerator;
    }
}