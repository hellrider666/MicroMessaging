namespace MicroMessaging.CommonsHelper.Helpers.Serialization.Json
{
    public static class JSONSerializationExtensions
    {
        public static string ToJson<T>(this T source)
        {
            return new JSONSerializationsHelper().Serialize(source);
        }

        public static string ToJson<T>(this T source, bool useFormating)
        {
            return new JSONSerializationsHelper(useFormating).Serialize(source);
        }

    }
}
