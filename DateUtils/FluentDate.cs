using System;

namespace DanTheDev.DateUtils
{
    public class FluentDate
    {
        public static FluentDate FromYear(int year)
        {
            return new FluentDate().Year(year);
        }

        private DateTime _dt;

        public FluentDate() : this(new DateTime())
        {
        }

        public FluentDate(DateTime dateTime) => _dt = dateTime;

        public DateTime DateTime => _dt;

        public FluentDate Year(int year)
        {
            var dt = new DateTime(year, _dt.Month, _dt.Day, _dt.Hour, _dt.Minute, _dt.Second, _dt.Kind);

            return new FluentDate(dt);
        }

        public FluentDate Month(int month)
        {
            var dt = new DateTime(_dt.Year, month, _dt.Day, _dt.Hour, _dt.Minute, _dt.Second, _dt.Kind);
            return new FluentDate(_dt);
        }

        public FluentDate Day(int day)
        {
            var dt = new DateTime(_dt.Year, _dt.Month, day, _dt.Hour, _dt.Minute, _dt.Second, _dt.Kind);
            return new FluentDate(dt);
        }

        public FluentDate AddDays(int num)
        {
            var dt = _dt.AddDays(num);
            return new FluentDate(dt);
        }

        public FluentDate Time(string s)
        {
            var dayTime = DayTime.Parse(s);
            var dt = dayTime.ToDayTimeUtc(_dt);
            return new FluentDate(dt);
        }

        public DateRange ToDayTimeRange(string s, string e)
        {
            var dayTimeRange = new DayTimeRange(s, e);
            return dayTimeRange.GetDateRange(_dt);
        }
    }
}