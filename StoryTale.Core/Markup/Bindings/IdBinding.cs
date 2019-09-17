using System;
using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;

namespace StoryTale.Core.Markup.Bindings
{
    public class IdBinding : IBinding
    {
        public Func<Tree, JToken> TryCreate(object obj)
        {
            return obj is IdBind bind ?
                    (tree => tree.Servers[bind.Id].Out.SelectToken(bind.Path ?? string.Empty)) :
                default(Func<Tree, JToken>);
        }
    }
}