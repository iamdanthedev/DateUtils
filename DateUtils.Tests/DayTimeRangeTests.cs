using System;
using Bonliva.DateUtils;
using Xunit;

namespace DateUtils.Tests
{
    public class DayTimeRangeTests
    {
        [Fact]
        public void Test00To24()
        {
            var d = new DayTimeRange("00:00", "00:00");
            var dateRange = d.GetDateRange(new DateTime(2021, 7, 12));
            Assert.Equal(new DateTime(2021, 7, 12, 0, 0, 0), dateRange.StartDateTime);
            Assert.Equal(new DateTime(2021, 7, 13, 0, 0, 0), dateRange.EndDateTime);
        }
    }
}