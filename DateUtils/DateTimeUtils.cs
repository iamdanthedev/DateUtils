using System;
using System.Collections.Generic;

namespace Bonliva.DateUtils
{
    public static class DateTimeUtils
    {
        public delegate void ForEachCallback(DateTime dt, int index);

        public static DateTime Clamp(this DateTime dt, DateTime min, DateTime max)
        {
            if (dt < min)
                return min;

            if (dt > max)
                return max;

            return dt;
        }

        public static void ForEach(this DateTime dt, TimeSpan each, DateTime until, ForEachCallback cb)
        {
            var current = dt;
            var index = 0;

            while (current < until)
            {
                cb(current, index);
                current = current.Add(each);
                index++;
            }
        }

        public static IEnumerable<DateTime> GetDaysUntil(this DateTime dt, DateTime until)
        {
            var current = dt;
            var each = TimeSpan.FromDays(1);

            while (current < until)
            {
                yield return current;
                current = current.Add(each);
            }
        }

        public static bool IsWorkDay(this DateTime dt)
        {
            return dt.DayOfWeek.IsWorkDay();
        }


        public static bool IsWorkDay(this DayOfWeek d)
        {
            return d != DayOfWeek.Saturday && d != DayOfWeek.Sunday;
        }

        public static int ToIsoDayNumber(this DayOfWeek d)
        {
            return d switch
            {
                DayOfWeek.Monday => 0,
                DayOfWeek.Tuesday => 1,
                DayOfWeek.Wednesday => 2,
                DayOfWeek.Thursday => 3,
                DayOfWeek.Friday => 4,
                DayOfWeek.Saturday => 5,
                DayOfWeek.Sunday => 6,
                _ => throw new ArgumentOutOfRangeException(nameof(d), d, null)
            };
        }

        public static bool IsBetween(this DayOfWeek d, DayOfWeek s, DayOfWeek e)
        {
            return s < e ? d >= s && d <= e : d <= s || d >= e;
        }

        public static DateTime StartOfMonth(this DateTime dt)
        {
            return new(dt.Year, dt.Month, 1, 0, 0, 0);
        }

        public static DateTime StartOfWeek(this DateTime dt)
        {
            return dt.WeekYear().ToDate(DayOfWeek.Monday);
        }
    }
}