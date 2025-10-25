using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Finance;

public class FinanceGeneratorDescriptor : GeneratorDescriptor
{

    public FinanceType FinanceType
    {
        get => (FinanceType)_arguments["FinanceType"];
        set => _arguments["FinanceType"] = value;
    }

    public override string GeneratorName => "Finance";
}