using System.Reflection;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Extensions;

public static class DataGetExtensions
{
    public static IEnumerable<object?> EnumerateProperties(this GeneratedType @this)
    {
        var type = @this.GetType();
        var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var property in properties) {
            var value = property.GetMethod?.Invoke(@this, null);
            yield return value;
        }
    }

    public static object? ReadProperty(this GeneratedType @this, string propName)
    {
        ArgumentNullException.ThrowIfNull(propName);
        var type = @this.GetType();
        var info = type.GetProperty(propName,BindingFlags.Instance | BindingFlags.Public);
        return info?.GetValue(@this, null);
    }
}