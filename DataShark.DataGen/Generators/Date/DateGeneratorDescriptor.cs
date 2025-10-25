using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Date;

public class DateGeneratorDescriptor : GeneratorDescriptor
{
    public DateType DateType
    {
        get => (DateType)Arguments["DateType"];
        set => _arguments["DateType"] = value;
    }
    public DateTime DateStart
    {
        get => (DateTime)Arguments["DateStart"];
        set => _arguments["DateStart"] = value;
    }
    public DateTime DateEnd
    {
        get => (DateTime)Arguments["DateEnd"];
        set => _arguments["DateEnd"] = value;
    }
    public DateTimeOffset DateOffsetStart
    {
        get => (DateTimeOffset)Arguments["DateOffsetStart"];
        set => _arguments["DateOffsetStart"] = value;
    }
    public DateTimeOffset DateOffsetEnd
    {
        get => (DateTimeOffset)Arguments["DateOffsetEnd"];
        set => _arguments["DateOffsetEnd"] = value;
    }
    public DateOnly DateOnlyStart
    {
        get => (DateOnly)Arguments["DateOnlyStart"];
        set => _arguments["DateOnlyStart"] = value;
    }
    public DateOnly DateOnlyEnd
    {
        get => (DateOnly)Arguments["DateOnlyEnd"];
        set => _arguments["DateOnlyEnd"] = value;
    }
    public TimeOnly TimeOnlyStart
    {
        get => (TimeOnly)Arguments["TimeOnlyStart"];
        set => _arguments["TimeOnlyStart"] = value;
    }
    public TimeOnly TimeOnlyEnd
    {
        get => (TimeOnly)Arguments["TimeOnlyEnd"];
        set => _arguments["TimeOnlyEnd"] = value;
    }
    public TimeSpan MaxTimeSpan
    {
        get => (TimeSpan)Arguments["MaxTimeSpan"];
        set => _arguments["MaxTimeSpan"] = value;
    }
    public DateTime RefDate
    {
        get => (DateTime)Arguments["RefDate"];
        set => _arguments["RefDate"] = value;
    }
    public DateOnly RefDateOnly
    {
        get => (DateOnly)Arguments["RefDateOnly"];
        set => _arguments["RefDateOnly"] = value;
    }
    public DateTimeOffset RefDateOffset
    {
        get => (DateTimeOffset)Arguments["RefDateOffset"];
        set => _arguments["RefDateOffset"] = value;
    }
    public TimeOnly RefTimeOnly
    {
        get => (TimeOnly)Arguments["RefTimeOnly"];
        set => _arguments["RefTimeOnly"] = value;
    }
    public int Days
    {
        get => (int)Arguments["Days"];
        set => _arguments["Days"] = value;
    }
    public int Years
    {
        get => (int)Arguments["Years"];
        set => _arguments["Years"] = value;
    }
    public bool WeekDayAbbrviated
    {
        get => (bool)Arguments["WeekDayAbbrviated"];
        set => _arguments["WeekDayAbbrviated"] = value;
    }
    public override string GeneratorName => "Date";
}