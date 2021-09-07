using System;

namespace DanTheDev.DateUtils
{
    public class DateRange : Interval
    {
        public static DateRange FromInterval(Interval interval)
        {
            return new DateRange(UnixTime.ToDateTime(interval.Start),
                UnixTime.ToDateTime(interval.End));
        }

        public DateRange(DateTime start, DateTime end) : base(UnixTime.ToUnixTimeSeconds(start),
            UnixTime.ToUnixTimeSeconds(end))
        {
        }

        public DateRange(uint start, uint end) : base(start, end)
        {
        }

        public DateTime StartDateTime => UnixTime.ToDateTime(Start);
        public DateTime EndDateTime => UnixTime.ToDateTime(End);

        public TimeSpan TimeSpan => EndDateTime - StartDateTime;

        public bool OverlapsWith(DateRange dateRange)
        {
            var (a1, b1) = (StartDateTime, EndDateTime);
            var (a2, b2) = (dateRange.StartDateTime, dateRange.EndDateTime);

            return (a2 < b1 && b2 > a1) || (a1 < b2 && b1 > a2);
        }

        public override string ToString()
        {
            return $"{StartDateTime:s} - {EndDateTime:s}";
        }

        public DateRange GetDateRangeWithin(DayTime start, DayTime end)
        {
            var startDateTime = start.Seconds >= StartDateTime.ToDayTime()
                .Seconds
                ? start.ToDayTimeUtc(StartDateTime.Date)
                : start.ToDayTimeUtc(StartDateTime.Date.AddDays(1));

            var endDateTime = end.Seconds < EndDateTime.ToDayTime()
                .Seconds
                ? end.ToDayTimeUtc(EndDateTime.Date)
                : end.ToDayTimeUtc(EndDateTime.Date.AddDays(-1));

            return new DateRange(startDateTime, endDateTime);
        }
    }
}