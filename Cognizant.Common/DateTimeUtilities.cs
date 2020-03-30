using System;
namespace Cognizant.Common
{
    public static class DateTimeUtilities
    {
        public static DateTime GetDayStarted(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }

        public static DateTime GetDayFinished(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }
    }
}
