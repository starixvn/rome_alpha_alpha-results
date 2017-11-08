namespace Alpha.Results.Site.Services.Impl
{
    using Newtonsoft.Json;

    public class JsonConverterImpl : Fanex.Result.ThirdParty.Services.JsonConverter
    {
        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
