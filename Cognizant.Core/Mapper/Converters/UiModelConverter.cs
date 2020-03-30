using System;

namespace Cognizant.Core.Mapper.Converters
{
    public static class UiModelConverter
    {
        public static DateTime ConvertStringToDate(string date)
        {
            var parsed = DateTime.TryParse(date, out var dateTime);
            if (parsed)
            {
                return dateTime;
            }
            return DateTime.MinValue;
        }
    }
}
