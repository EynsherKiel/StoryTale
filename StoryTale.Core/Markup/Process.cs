using StoryTale.Core.Data;
using System;
using System.Collections.Generic;
using StoryTale.Core.Extensions;

namespace StoryTale.Core.Markup
{
    public class Process
    {
        private readonly Tree _source;
        private readonly IDictionary<int, Func<Tree, object>> _bindings;

        public Process(Tree source, IDictionary<int, Func<Tree, object>> bindings, object global)
        {
            _bindings = bindings;

            _source = source;
            _source.Global = global.ToLowerJToken();
        }

        public void SetOut(Server server, string @out)
        {
            _source.Servers[server.Id].Out = @out.ToLowerJToken();
        }

        public IEnumerable<Server> Visit()
        {
            return _source.Nodes.Visit(item => true);
        }

        public object GetIn(Server server)
        {
            return _bindings[server.Id](_source);
        }
    }
}