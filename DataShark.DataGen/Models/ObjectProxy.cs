using System.Reflection;

namespace DataShark.DataGen.Models;

public class ObjectProxy(object obj)
{
    private object ContainedObject { get; } = obj;

    public object? GetValue(string propertyName)
    {
        if(string.IsNullOrEmpty(propertyName))
            throw new ArgumentNullException(nameof(propertyName));
        return ContainedObject.GetType().GetProperty(propertyName)?.GetValue(ContainedObject);
    }

    public void SetValue(string propertyName, object? value)
    {
        if(string.IsNullOrEmpty(propertyName))
            throw new ArgumentNullException(nameof(propertyName));
        ContainedObject.GetType().GetProperty(propertyName)?.SetValue(ContainedObject, value);
    }

    public IEnumerable<object?> GetValues()
    {
        if (ContainedObject == null) throw new NullReferenceException("Trying to access null contained object");
        
        var props = ContainedObject
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var propertyInfo in props)
        {
            yield return propertyInfo.GetValue(ContainedObject);
        }
    }
}
