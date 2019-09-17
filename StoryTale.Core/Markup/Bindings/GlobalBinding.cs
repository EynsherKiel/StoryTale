using System;
using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;

namespace StoryTale.Core.Markup.Bindings
{
    public class GlobalBinding : IBinding
    {
        public Func<Map, JToken> TryCreate(object obj)
        {
            return obj is GlobalBind bind ? 
                    (map => map.Global.SelectToken(bind.Path ?? string.Empty)) :
                default(Func<Map, JToken>);
        }
    }
}
