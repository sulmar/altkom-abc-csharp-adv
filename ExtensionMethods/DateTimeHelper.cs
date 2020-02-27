using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtensionMethods.Helpers
{
    public class DateTimeHelper
    {
        public static bool IsHoliday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday 
                || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public static class DateTimeExtensions
    {
        public static bool IsHoliday(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsHoliday(this DateTime date, params DayOfWeek[] dayOfWeeks)
        {
            return dayOfWeeks.Contains(date.DayOfWeek);
        }

        public static DateTime AddWorkingDays(this DateTime date, int days)
        {
            return date.AddDays(days);
        }

        public static bool IsDaylightSavingTime(this DateTime date)
        {
            return true;
        }
    }


}
