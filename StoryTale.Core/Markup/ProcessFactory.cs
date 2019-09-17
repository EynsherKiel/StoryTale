using Force.DeepCloner;
using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTale.Core.Markup
{
    public class ProcessFactory
    {
        private readonly Tree _source;
        private readonly IDictionary<int, Func<Tree, object>> _bindings;

        public ProcessFactory(Map source, BindingFactory binding)
        {
            _source = new Tree
            {
                Servers = source.Servers.ToDictionary(server => server.Id),
                Nodes = source.GetTree()
            };

            _bindings = _source.Servers.ToDictionary(
                server => server.Key,
                server => binding.Create(server.Value.In));
        }

        public Process CreateProcess(object global) => new Process(_source.DeepClone(), _bindings, global);
    }
}
