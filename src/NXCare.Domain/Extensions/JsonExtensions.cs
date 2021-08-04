namespace NXCare.Domain.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object source)
        {
            return System.Text.Json.JsonSerializer.Serialize(source);
        }

        public static T FromJson<T>(this string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(json);
        }
    }
}
