namespace DataShark.DataGen.Models;

public class DatasetGenerationResult(string datasetName)
{
    public string DatasetName { get; set; } = datasetName;
    public IList<TableGenerationResult> Tables { get; set; } = [];
}
