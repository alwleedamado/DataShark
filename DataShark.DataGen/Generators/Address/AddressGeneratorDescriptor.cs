using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Address;

public class AddressGeneratorDescriptor : GeneratorDescriptor
{
    public AddressType AddressType
    {
        get => (AddressType)_arguments["AddressType"];
        set => _arguments["AddressType"] = value;
    }

    public override string GeneratorName => "Address";
}