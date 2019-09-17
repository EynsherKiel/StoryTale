using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTale.Core.Markup
{
    public class MapMarkup
    {
        private readonly Map _source;
        private readonly Node<Server> _tree;
        private readonly Dictionary<int, Func<ProcessToken, object>> _bindings;

        public MapMarkup(Map source, BindingFactory binding)
        {
            _source = source;
            _tree = _source.GetTree();

            _bindings = _source.Servers.ToDictionary(
                server => server.Id,
                server => binding.Create(server.In));
        }

        public Process CreateProcess(object global) => new Process(_source, _tree, _bindings, global);
    }
}