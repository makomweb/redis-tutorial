using Newtonsoft.Json;

namespace Redis.Tutorial.Dotnet
{
    public static class JsonEncoder
    {
        public static string AsJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
