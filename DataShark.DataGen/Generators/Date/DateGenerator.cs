using Bogus;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Date;

public class DateGenerator(GeneratorDescriptor descriptor) : Generator(descriptor)
{
    public override Func<Faker, T, TPropType> Generate<T, TPropType>()
    {
        var descriptor = (DateGeneratorDescriptor)base.Descriptor;

        return descriptor.DateType switch
        {
            DateType.Between => (f, _) => Convert<TPropType>(f.Date.Between(descriptor.DateStart, descriptor.DateEnd)),
            DateType.BetweenDateOnly => (f, _) => Convert<TPropType>(f.Date.BetweenDateOnly(descriptor.DateOnlyStart, descriptor.DateOnlyEnd)),
            DateType.BetweenOffset => (f, _) => Convert<TPropType>(f.Date.BetweenOffset(descriptor.DateOffsetStart, descriptor.DateOffsetEnd)),
            DateType.BetweenTimeOnly => (f, _) => Convert<TPropType>(f.Date.BetweenTimeOnly(descriptor.TimeOnlyStart, descriptor.TimeOnlyEnd)),
            DateType.Future => (f, _) => Convert<TPropType>(f.Date.Future(descriptor.Years, descriptor.RefDate)),
            DateType.FutureDateOnly => (f, _) => Convert<TPropType>(f.Date.FutureDateOnly(descriptor.Years, descriptor.RefDateOnly)),
            DateType.FutureOffset => (f, _) => Convert<TPropType>(f.Date.FutureOffset(descriptor.Years, descriptor.RefDateOffset)),
            DateType.Month => (f, _) => Convert<TPropType>(f.Date.Month()),
            DateType.Past => (f, _) => Convert<TPropType>(f.Date.Past(descriptor.Years,descriptor.RefDate)),
            DateType.PastDateOnly => (f, _) => Convert<TPropType>(f.Date.PastDateOnly(descriptor.Years, descriptor.RefDateOnly)),
            DateType.PastOffset => (f, _) => Convert<TPropType>(f.Date.PastOffset(descriptor.Years, descriptor.RefDateOffset)),
            DateType.Recent => (f, _) => Convert<TPropType>(f.Date.Recent(descriptor.Days, descriptor.RefDate)),
            DateType.RecentDateOnly => (f, _) => Convert<TPropType>(f.Date.RecentDateOnly(descriptor.Days, descriptor.RefDateOnly)),
            DateType.RecentOffset => (f, _) => Convert<TPropType>(f.Date.RecentOffset(descriptor.Days, descriptor.RefDateOffset)),
            DateType.RecentTimeOnly => (f, _) => Convert<TPropType>(f.Date.RecentTimeOnly(descriptor.Days, descriptor.RefTimeOnly)),
            DateType.Soon => (f, _) => Convert<TPropType>(f.Date.Soon(descriptor.Days, descriptor.RefDate)),
            DateType.SoonDateOnly => (f, _) => Convert<TPropType>(f.Date.SoonDateOnly(descriptor.Days, descriptor.RefDateOnly)),
            DateType.SoonOffset => (f, _) => Convert<TPropType>(f.Date.SoonOffset(descriptor.Days, descriptor.RefDateOffset)),
            DateType.SoonTimeOnly => (f, _) => Convert<TPropType>(f.Date.SoonTimeOnly(descriptor.Days, descriptor.RefTimeOnly)),
            DateType.TimeSpan => (f, _) => Convert<TPropType>(f.Date.Timespan(descriptor.MaxTimeSpan)),
            DateType.TimeZoneString => (f, _) => Convert<TPropType>(f.Date.TimeZoneString()),
            DateType.WeekDay => (f, _) => Convert<TPropType>(f.Date.Weekday(descriptor.WeekDayAbbrviated)),
            _ => throw new NotImplementedException(),
        };
    }

}
