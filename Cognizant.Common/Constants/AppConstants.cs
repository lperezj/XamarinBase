using System;

namespace Cognizant.Common.Constants
{
    public static class AppConstants
    {
        public static string API_KEY = "FC-Api-Key";

        public static string ACCESS_TOKEN = "FC-Access-Token";

        public const string DATE_FORMAT_STRINGFORMAT = "{0:MM/dd/yyyy}";
        public const string DATE_FORMAT_STRING_SHORTFORMAT = "{0:dd MMMM}";
        public const string DATE_FORMAT_TOSTRING = "MM/dd/yyyy";

        // Sortable date/time: "{0:s}", date): 2020-01-15T09:31:52
        public const string DATE_FORMAT_STRINGFORMAT_SORTABLE = "{0:s}";

        public const string FOCUSABLE_PROPERTY = "Focusable";
        public const string TIME_PROPERTY = "Time";

        public static bool ForceRefresh; // Monkey Cache Constant

        public static string APP_ID = "APP.DEV"; // Monkey Application Id

        public static int MaxExpirationDate = 1;

        public static string MESSAGE_OTHER = nameof(MESSAGE_OTHER);
        public static string MESSAGE_REFRESH_ALL_APP = nameof(MESSAGE_REFRESH_ALL_APP);
        public static string MESSAGE_RESTART_ALL_APP = nameof(MESSAGE_RESTART_ALL_APP);
    }
}