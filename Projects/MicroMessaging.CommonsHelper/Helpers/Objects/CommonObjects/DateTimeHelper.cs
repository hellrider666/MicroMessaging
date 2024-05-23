namespace MicroMessaging.CommonsHelper.Helpers.Objects.CommonObjects
{
    public static class DateTimeHelper
    {
        private const string EU_FORMAT = "dd/MM/yyyy HH:mm:ss";
        public static string ToEUFormatDateTimeToString(this DateTime dateTime)
        {
            return dateTime.ToString(EU_FORMAT);
        }

    }
}
