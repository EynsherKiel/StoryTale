using System;
using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;

namespace StoryTale.Core.Markup.Bindings
{
    public class IdBinding : IBinding
    {
        public Func<ProcessData, JToken> TryCreate(object obj)
        {
            return obj is IdBind bind ?
                    (tree => tree.Outs[bind.Id].SelectToken(bind.Path ?? string.Empty)) :
                default(Func<ProcessData, JToken>);
        }
    }
}