using Bogus;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Company;

public class CompanyGenerator(GeneratorDescriptor descriptor) : Generator(descriptor)
{
    public override Func<Faker, T, TPropTyype> Generate<T, TPropTyype>()
    {
        var descriptor = (CompanyDescriptor)base.Descriptor;

        return descriptor.CompanyOptions switch
        {
            CompanyOptions.CompanyName => (f, _) => Convert<TPropTyype>(f.Company.CompanyName()),
            CompanyOptions.CompanySuffix => (f, _) => Convert<TPropTyype>(f.Company.CompanySuffix()),
            _ => throw new InvalidOperationException($"This parameter is not supported")
        };
    }
}
