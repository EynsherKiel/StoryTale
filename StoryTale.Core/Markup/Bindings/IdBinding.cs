using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;

namespace StoryTale.Core.Markup.Bindings
{
    public class IdBinding : IBinding
    {
        public Func<Map, JToken> TryCreate(object obj)
        {
            return obj is IdBind bind ?
                    (map => map.Servers.Single(s => s.Id == bind.Id).Out.SelectToken(bind.Path ?? string.Empty)) :
                default(Func<Map, JToken>);
        }
    }
}