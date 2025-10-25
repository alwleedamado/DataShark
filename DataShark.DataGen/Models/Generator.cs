using Bogus;

// ReSharper disable PublicConstructorInAbstractClass

namespace DataShark.DataGen.Models;

public abstract class Generator
{
    protected static T Convert<T>(object value) => (T)value;

    public abstract Func<Faker, T, TPropType> Generate<T, TPropType>() where T : class;
}
