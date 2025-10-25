using Bogus;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Name;

public class NameGenerator(GeneratorDescriptor descriptor) : Generator(descriptor)
{
    public override Func<Faker, T, R> Generate<T, R>()
    {
        var descriptor = (NameGeneratorDescriptor)base.Descriptor;
            
        return descriptor.NameType switch
        {
            NameType.FullName => (f, _) => Convert<R>(f.Name.FullName(ConvertGender(descriptor.Gender))),
            NameType.FirstName => (f, _) => Convert<R>(f.Name.FirstName(ConvertGender(descriptor.Gender))),
            NameType.LastName => (f, _) => Convert<R>(f.Name.LastName(ConvertGender(descriptor.Gender))),
            NameType.Prefix => (f, _) => Convert<R>(f.Name.Prefix(ConvertGender(descriptor.Gender))),
            NameType.JobArea => (f, _) => Convert<R>(f.Name.JobArea()),
            NameType.JobDescription => (f, _) => Convert<R>(f.Name.JobDescriptor()),
            NameType.JobTitle => (f, _) => Convert<R>(f.Name.JobTitle()),
            NameType.JobType => (f, _) => Convert<R>(f.Name.JobType()),
            _ => throw new NotImplementedException(),
        };
    }
    private static Bogus.DataSets.Name.Gender ConvertGender(Gender gender)
    {
        return gender == Gender.Male ? Bogus.DataSets.Name.Gender.Male : Bogus.DataSets.Name.Gender.Female;
    }
}
