using System.Collections.Generic;
using Bonliva.DateUtils;
using FluentAssertions;
using NUnit.Framework;

namespace DateUtils.Tests
{
    [TestOf(typeof(DateRange))]
    public class DateRangeTests
    {
        
        [Test]
        [TestCaseSource(nameof(GetOverlapsWithTestData))]
        public void OverlapsWith1(OverlapWithTestData d)
        {
            d.Range2.OverlapsWith(d.Range1).Should().Be(d.Overlaps);
        }

        public static IEnumerable<OverlapWithTestData> GetOverlapsWithTestData()
        {
            var day1 = FluentDate.FromYear(2021).Month(1).Day(1);

            yield return new OverlapWithTestData(
                day1.ToDayTimeRange("08:00", "12:00"),
                day1.ToDayTimeRange("12:00", "13:00"),
                false
            );
            
            yield return new OverlapWithTestData(
                day1.ToDayTimeRange("08:00", "12:00"),
                day1.ToDayTimeRange("13:00", "14:00"),
                false
            );
            
            yield return new OverlapWithTestData(
                day1.ToDayTimeRange("08:00", "12:00"),
                day1.ToDayTimeRange("09:00", "12:00"),
                true
            );
            
            yield return new OverlapWithTestData(
                day1.ToDayTimeRange("08:00", "12:00"),
                day1.ToDayTimeRange("11:00", "13:00"),
                true
            );
        }
    }

    public record OverlapWithTestData(DateRange Range1, DateRange Range2, bool Overlaps);
}