using DataShark.DataGen;
using DataShark.DataGen.Generators.Name;
using DataShark.DataGen.Models;
using DataShark.DataGen.Writers;

namespace DataShark.DataGet.UnitTests;

public class NameGeneratorTests
{
    private GenerationContext _context;
    [SetUp]
    public void Setup()
    {
        _context = new GenerationContext();
    }

    [Test]
    public void ShouldGenerateFirstName()
    {
        var gen = new NameGenerator(NameType.FirstName);
        var table = new Table("Employee");
        table.AddColumn(new Column()
        {
            Generator = gen,
            ClrType = ClrType.String,
            Name = "FirstName"
        });
        var generated = _context.GenerateSingleTable(table);
        Assert.That(generated.Any());
    }
    
    [Test]
    public void ShouldGenerateFirstNameByGender()
    {
        var gen = new NameGenerator(NameType.FirstName);
        gen.Gender = Gender.Female;
        var table = new Table("SalesWomen");
        table.AddColumn(new Column()
        {
            Generator = gen,
            ClrType = ClrType.String,
            Name = "FirstName"
        });
        var generated = _context.GenerateSingleTable(table);
        Assert.That(generated.Any());
    }

    [Test]
    public void ShouldGenerateMany()
    {
        var gen = new NameGenerator(NameType.FirstName);
        gen.Gender = Gender.Female;
        var table = new Table("Managers");
        table.AddColumn(new Column()
        {
            Generator = gen,
            ClrType = ClrType.String,
            Name = "FirstName"
        });
        var generated = _context.GenerateSingleTable(table, 100);
        Assert.That(generated.Count(), Is.EqualTo(100));
    }
}
