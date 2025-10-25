using Bogus;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Name;

public class NameGenerator(NameType nameType) : Generator
{
    public Gender Gender { get; set; }
    public NameType NameType { get; set; } = nameType;
    public override Func<Faker, T, R> Generate<T, R>()
    {
        return NameType switch
        {
            NameType.FullName => (f, _) => Convert<R>(f.Name.FullName(ConvertGender(Gender))),
            NameType.FirstName => (f, _) => Convert<R>(f.Name.FirstName(ConvertGender(Gender))),
            NameType.LastName => (f, _) => Convert<R>(f.Name.LastName(ConvertGender(Gender))),
            NameType.Prefix => (f, _) => Convert<R>(f.Name.Prefix(ConvertGender(Gender))),
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
