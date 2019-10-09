using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace StoryTale.Core.Extensions
{
    //https://github.com/JamesNK/Newtonsoft.Json/issues/815
    //
    // A few years have passed. What reason not to do it so far?
    // -_-
    //
    public static class JsonExtensions
    {
        public static JToken ToLowerJToken(this object obj)
            => JsonConvert.SerializeObject(obj).ToLowerJToken();

        public static JToken ToLowerJToken(this string json)
        {
            using var textReader = new StringReader(json);
            using var jsonReader = new LowerCasePropertyNameJsonReader(textReader);

            return new JsonSerializer().Deserialize<JToken>(jsonReader);
        }

        public class LowerCasePropertyNameJsonReader : JsonTextReader
        {
            public LowerCasePropertyNameJsonReader(TextReader textReader) : base(textReader) { }

            public override object Value 
                => TokenType == JsonToken.PropertyName ? ((string)base.Value).ToLowerInvariant() : base.Value;
        }
    }
}
