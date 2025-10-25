using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Company;

public class CompanyDescriptor : GeneratorDescriptor
{
    public CompanyOptions CompanyOptions
    {
        get => (CompanyOptions)_arguments["CompanyOptions"];
        set => _arguments["CompanyOptions"] = value;
    }

    public override string GeneratorName => "Company";
}