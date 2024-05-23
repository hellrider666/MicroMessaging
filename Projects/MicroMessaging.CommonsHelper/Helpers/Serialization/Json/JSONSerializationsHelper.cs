using System.Text.Encodings.Web;
using System.Text.Json;

namespace MicroMessaging.CommonsHelper.Helpers.Serialization.Json
{
    public class JSONSerializationsHelper
    {
        public JsonSerializerOptions SerializerSettings { get; private set; }


        public JSONSerializationsHelper()
        {
            SerializerSettings = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }

        public JSONSerializationsHelper(JsonSerializerOptions serializerSettings)
        {
            SerializerSettings = serializerSettings;
        }

        public JSONSerializationsHelper(bool useFormatting) : this()
        {
            if (useFormatting)
                SerializerSettings.WriteIndented = useFormatting;
        }


        public string Serialize(object entity)
        {
            return JsonSerializer.Serialize(entity, SerializerSettings);
        }
    }
}
