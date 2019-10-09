using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StoryTale.Core.Markup
{
    public class BindingMap
    {
        private readonly Dictionary<IInputExpression, Func<ProcessData, JToken>> _bindings
            = new Dictionary<IInputExpression, Func<ProcessData, JToken>>();

        private readonly Dictionary<Condition, Func<JToken, bool>> _conditions
            = new Dictionary<Condition, Func<JToken, bool>>();

        private readonly Map _map;
        private readonly BindingFactory _binding;

        public BindingMap(Map map, BindingFactory binding)
        {
            _map = map;
            _binding = binding;
        }

        public BindingMap Registr(Func<Container, IInputExpression> selector)
        {
            RegistrBindings(_map.Containers.Select(selector));

            return this;
        }

        public BindingMap Registr(Func<Container, IEnumerable<Assert>> selector)
        {
            RegistrConditions(_map.Containers.SelectMany(selector));

            return this;
        }

        public BindingMap Registr(Func<Container, Assert> selector)
        {
            RegistrConditions(_map.Containers.Select(selector));

            return this;
        }

        public Func<JToken, bool> GetCondition(Condition input)
        {
            return _conditions[input];
        }

        public Func<ProcessData, JToken> GetBinding(IInputExpression input)
        {
            return _bindings[input];
        }

        private void RegistrBindings(IEnumerable<IInputExpression> conditions)
        {
            foreach (var condition in conditions)
            {
                AddBinding(condition);
            }
        }

        private void RegistrConditions(IEnumerable<Assert> asserts)
        {
            foreach (var condition in asserts.Select(assert => assert.Condition))
            {
                AddBinding(condition);
                AddCondition(condition);
            }
        }

        private void AddCondition(Condition input)
        {
            var condition = input.Expr?.ToLambda<JToken, bool>() ?? (token => true);

            _conditions.Add(input, condition);
        }

        private void AddBinding(IInputExpression input)
        {
            var binding = _binding.Create(input.In);

            _bindings.Add(input, binding);
        }
    }
}
