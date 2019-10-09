using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;
using System;

namespace StoryTale.Core.Markup.Bindings
{
    public interface IBinding
    {
        Func<ProcessData, JToken> TryCreate(object obj);
    }
}