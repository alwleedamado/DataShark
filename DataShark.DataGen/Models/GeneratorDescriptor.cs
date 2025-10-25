namespace DataShark.DataGen.Models;

public abstract class GeneratorDescriptor
{

    protected Dictionary<string, object> _arguments = new();
    public IReadOnlyDictionary<string, object> Arguments => _arguments.AsReadOnly();
    /// <summary>
    /// The name of the generator. Used for getting the generator class for
    /// dynamic generator creation to be used in column data generation
    /// </summary>
    public abstract string GeneratorName { get; }
    public void AddArgument(string name, object value)
    {
        _arguments.Add(name, value);
    }
    public object GetArgument(string name)
    {
        return _arguments[name];
    }
    public void RemoveArgument(string name)
    {
        _arguments.Remove(name);
    }
}