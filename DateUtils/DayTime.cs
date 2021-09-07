using System;

namespace Bonliva.DateUtils
{
    public class DayTime
    {
        public int Seconds { get; } = 0;

        public DayTime(int seconds)
        {
            Seconds = seconds;
        }

        public DayTime(uint seconds)
        {
            Seconds = (int) seconds;
        }

        // public double GetTimeDifference(DayTime value)
        // {
        //     return TimeSpan.FromMinutes(DateTime.Parse(value.ToString())
        //             .Subtract(DateTime.Parse(ToString()))
        //             .TotalMinutes)
        //         .TotalMinutes;
        // }

        // Parse HH:mm and return DayTime
        public static DayTime Parse(string val)
        {
            return new DayTime((int) TimeSpan.Parse(val).TotalSeconds);
        }

        // return HH:mm
        public override string ToString()
        {
            return TimeSpan.FromSeconds(Seconds).ToString(@"hh\:mm");
        }

        public DateTime ToDayTimeUtc(DateTime date)
        {
            return date.Date.Add(TimeSpan.FromSeconds(Seconds));
        }
    }
}