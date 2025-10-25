using Bogus;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Address;

public class AddressGenerator(AddressType type) : Generator
{
    public AddressType AddressType { get; } = type;
    
    public override Func<Faker, T, TPropType> Generate<T, TPropType>()
    {
        return AddressType switch
        {
            AddressType.Country => (f, _) => Convert<TPropType>(f.Address.Country()),
            AddressType.State => (f, _) => Convert<TPropType>(f.Address.State()),
            AddressType.StateAbbreviation => (f, _) => Convert<TPropType>(f.Address.StateAbbr()),
            AddressType.City => (f, _) => Convert<TPropType>(f.Address.City()),
            AddressType.BuildingNumber => (f, _) => Convert<TPropType>(f.Address.BuildingNumber()),
            AddressType.FullAddress => (f, _) => Convert<TPropType>(f.Address.FullAddress()),
            AddressType.SecondaryAddress => (f, _) => Convert<TPropType>(f.Address.SecondaryAddress()),
            AddressType.Latitude => (f, _) => Convert<TPropType>(f.Address.Latitude()),
            AddressType.Longitude => (f, _) => Convert<TPropType>(f.Address.Longitude()),
            AddressType.Direction => (f, _) => Convert<TPropType>(f.Address.Direction()),
            AddressType.CardinalDirection => (f, _) => Convert<TPropType>(f.Address.CardinalDirection()),
            AddressType.OrdinalDirection => (f, _) => Convert<TPropType>(f.Address.OrdinalDirection()),
            AddressType.ZipCode => (f, _) => Convert<TPropType>(f.Address.ZipCode()),
            AddressType.CountryCode => (f, _) => Convert<TPropType>(f.Address.CountryCode()),
            _ => throw new InvalidOperationException($"This parameter is not supported")
        };
    }
}
