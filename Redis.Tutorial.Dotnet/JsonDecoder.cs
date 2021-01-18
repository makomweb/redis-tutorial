using Newtonsoft.Json;

namespace Redis.Tutorial.Dotnet
{
    public static class JsonDecoder
    {
        public static dynamic Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<dynamic>(json);
        }
    }
}
