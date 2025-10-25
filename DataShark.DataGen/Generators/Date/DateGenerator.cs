using Bogus;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Date;

public class DateGenerator(DateType dateType) : Generator
{
    public DateType DateType { get; set; } = dateType;
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public DateTimeOffset DateOffsetStart { get; set; }
    public DateTimeOffset DateOffsetEnd { get; set; }
    public DateOnly DateOnlyStart { get; set; }
    public DateOnly DateOnlyEnd { get; set; }
    public TimeOnly TimeOnlyStart { get; set; }
    public TimeOnly TimeOnlyEnd { get; set; }
    public TimeSpan MaxTimeSpan { get; set; }
    public DateTime RefDate { get; set; }
    public DateOnly RefDateOnly { get; set; }
    public DateTimeOffset RefDateOffset { get; set; }
    public TimeOnly RefTimeOnly { get; set; }
    public int Days { get; set; }
    public int Years { get; set; }
    public bool WeekDayAbbreviated { get; set; }
    public override Func<Faker, T, TPropType> Generate<T, TPropType>()
    {
        return DateType switch
        {
            DateType.Between => (f, _) => Convert<TPropType>(f.Date.Between(DateStart, DateEnd)),
            DateType.BetweenDateOnly => (f, _) => Convert<TPropType>(f.Date.BetweenDateOnly(DateOnlyStart, DateOnlyEnd)),
            DateType.BetweenOffset => (f, _) => Convert<TPropType>(f.Date.BetweenOffset(DateOffsetStart, DateOffsetEnd)),
            DateType.BetweenTimeOnly => (f, _) => Convert<TPropType>(f.Date.BetweenTimeOnly(TimeOnlyStart, TimeOnlyEnd)),
            DateType.Future => (f, _) => Convert<TPropType>(f.Date.Future(Years, RefDate)),
            DateType.FutureDateOnly => (f, _) => Convert<TPropType>(f.Date.FutureDateOnly(Years, RefDateOnly)),
            DateType.FutureOffset => (f, _) => Convert<TPropType>(f.Date.FutureOffset(Years, RefDateOffset)),
            DateType.Month => (f, _) => Convert<TPropType>(f.Date.Month()),
            DateType.Past => (f, _) => Convert<TPropType>(f.Date.Past(Years,RefDate)),
            DateType.PastDateOnly => (f, _) => Convert<TPropType>(f.Date.PastDateOnly(Years, RefDateOnly)),
            DateType.PastOffset => (f, _) => Convert<TPropType>(f.Date.PastOffset(Years, RefDateOffset)),
            DateType.Recent => (f, _) => Convert<TPropType>(f.Date.Recent(Days, RefDate)),
            DateType.RecentDateOnly => (f, _) => Convert<TPropType>(f.Date.RecentDateOnly(Days, RefDateOnly)),
            DateType.RecentOffset => (f, _) => Convert<TPropType>(f.Date.RecentOffset(Days, RefDateOffset)),
            DateType.RecentTimeOnly => (f, _) => Convert<TPropType>(f.Date.RecentTimeOnly(Days, RefTimeOnly)),
            DateType.Soon => (f, _) => Convert<TPropType>(f.Date.Soon(Days, RefDate)),
            DateType.SoonDateOnly => (f, _) => Convert<TPropType>(f.Date.SoonDateOnly(Days, RefDateOnly)),
            DateType.SoonOffset => (f, _) => Convert<TPropType>(f.Date.SoonOffset(Days, RefDateOffset)),
            DateType.SoonTimeOnly => (f, _) => Convert<TPropType>(f.Date.SoonTimeOnly(Days, RefTimeOnly)),
            DateType.TimeSpan => (f, _) => Convert<TPropType>(f.Date.Timespan(MaxTimeSpan)),
            DateType.TimeZoneString => (f, _) => Convert<TPropType>(f.Date.TimeZoneString()),
            DateType.WeekDay => (f, _) => Convert<TPropType>(f.Date.Weekday(WeekDayAbbreviated)),
            _ => throw new NotImplementedException(),
        };
    }

}
