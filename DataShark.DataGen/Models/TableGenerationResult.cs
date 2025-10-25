namespace DataShark.DataGen.Models;

public class TableGenerationResult(string tableName, ObjectProxy result)
{
    public string TableName { get; set; } = tableName;
    public ObjectProxy Result { get; set; } = result;
}