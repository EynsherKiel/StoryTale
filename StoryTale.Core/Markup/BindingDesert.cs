using StoryTale.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryTale.Core.Markup
{
    public class BindingDesert
    {
        private readonly Dictionary<int, Func<ProcessToken, object>> _inBindings;

        public BindingDesert(Map source, BindingFactory binding)
        {
            _inBindings = source.Servers.ToDictionary(
                server => server.Id,
                server => binding.Create(server.In));
        }
    }
}
