using StoryTale.Core.Data;
using System;
using System.Collections.Generic;
using StoryTale.Core.Extensions;

namespace StoryTale.Core.Markup
{
    public class Process
    {
        private readonly ProcessToken _token = new ProcessToken();

        private readonly Dictionary<int, Func<ProcessToken, object>> _bindings;
        private readonly Node<Server> _tree;
        private readonly Map _source;

        public Process(Map source, Node<Server> tree, Dictionary<int, Func<ProcessToken, object>> bindings, object global)
        {
            _bindings = bindings;
            _tree = tree;
            _source = source;

            _token.Global = global.ToLowerJToken();
        }

        public void SetOut(Server server, string @out)
        {
            _token.Outs[server.Id] = @out.ToLowerJToken();
        }

        public IEnumerable<Server> Visit()
        {
            return _tree.Visit(item => true);
        }

        public object GetIn(Server server)
        {
            return _bindings[server.Id](_token);
        }
    }
}