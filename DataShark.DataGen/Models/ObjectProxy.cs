namespace DataShark.DataGen.Models;

public class ObjectProxy(object obj)
{
    public object ContainedObject { get; } = obj;

    public object? GetPropertyValue(string propertyName)
    {
        if(string.IsNullOrEmpty(propertyName))
            throw new ArgumentNullException(nameof(propertyName));
        return ContainedObject?.GetType().GetProperty(propertyName)?.GetValue(ContainedObject);
    }

    public void SetPropertyValue(string propertyName, object? value)
    {
        if(string.IsNullOrEmpty(propertyName))
            throw new ArgumentNullException(nameof(propertyName));
        ContainedObject?.GetType().GetProperty(propertyName)?.SetValue(ContainedObject, value);
    }
}