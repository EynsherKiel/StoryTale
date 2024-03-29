﻿using System;
using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;

namespace StoryTale.Core.Markup.Bindings
{
    public class GlobalBinding : IBinding
    {
        public Func<ProcessData, JToken> TryCreate(object obj)
        {
            return obj is GlobalBind bind ? 
                    (tree => tree.Global.SelectToken(bind.Path ?? string.Empty)) :
                default(Func<ProcessData, JToken>);
        }
    }
}