using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using System.Linq;

namespace StoryTale.Core.Markup
{
    public class ProcessToken
    {
        private readonly ProcessData _data;
        private readonly BindingMap _bindingMap;

        public ProcessToken(object global, BindingMap bindingMap)
        {
            _data = new ProcessData
            {
                Global = global.ToLowerJToken()
            };

            _bindingMap = bindingMap;
        }

        public void AddPath(int id) => _data.Path.Add(id);
        public bool CheckPath(int[] ids) => ids?.All(_data.Path.Contains) ?? true;
        public void SetOut(int id, string @out) => _data.Outs[id] = @out.ToLowerJToken();
        public JToken GetIn(IInputExpression input) => _bindingMap.GetBinding(input)(_data);
        public bool CheckCondition(Condition input, JToken @in) => _bindingMap.GetCondition(input)(@in);
    }
}