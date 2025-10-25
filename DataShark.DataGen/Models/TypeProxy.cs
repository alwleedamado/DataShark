using System.Reflection;

namespace DataShark.DataGen.Models;

public class TypeProxy(string typeName, Type type)
{
    public string TypeName { get; } = typeName;
    public Type Type { get; } = type;

    public object CreateInstance()
    {
        return Activator.CreateInstance(Type)!;
    }
    public object? GetValue(object target, string propertyName)
    {
        var info = Type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public)
                   ?? throw new InvalidOperationException($"Property {propertyName} does not exist.");
        var getMethod = info.GetMethod
                        ?? throw new AccessViolationException($"Can not access property {propertyName} GetMethod");
        return getMethod.Invoke(target, []);
    }
    public void SetValue(object target, string propertyName, object value)
    {
        var info = Type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public)
                   ?? throw new InvalidOperationException($"Property {propertyName} does not exist.");
        var setMethod = info.SetMethod
                        ?? throw new AccessViolationException($"Can not access property {propertyName} SetMethod");
        setMethod.Invoke(target, [value]);
    }
    public IEnumerable<object?> IterateProperties(object target)
    {
        var info = Type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var property in info)
        {
            yield return GetValue(target, property.Name);
        }
    }
    public IEnumerable<PropertyInfo> GetProperties()
    {
        var info = Type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var property in info)
        {
            yield return property;
        }
    }
    public object? CallMethod(object target, string methodName, BindingFlags flags, params object[] args)
    {
        var method = Type.GetMethod(methodName, flags) ??
                     throw new MethodAccessException(methodName);
        return method.Invoke(target, args);
    }
}
