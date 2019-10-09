using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using StoryTale.Core.Markup.Moduls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTale.Core.Markup
{
    public class Pipeline
    {
        private readonly Node<Container> _tree;
        private readonly BindingMap _bindingMap;
        private readonly ServerModule _serverModule;

        public Pipeline(Node<Container> tree, BindingMap bindingMap, ServerModule serverModule)
        {
            _tree = tree;
            _bindingMap = bindingMap;
            _serverModule = serverModule;
        }

        // todo: Add Chain architecture
        // -- pipe.Next() -> nothing or element
        // -- like ienumerator, but without idisposable
        // -- it's will be work little bit lower, but more clearance architecture
        // --
        // -- and inside work with exceptions... fuck
        public async IAsyncEnumerable<Step> ExecuteProcess(object global)
        {
            static Step Step(Node<Container> current, string step, object data)
            {
                return new Step
                {
                    Id = current.Current.Id,
                    ModuleName = current.Current.Name,
                    Name = step,
                    Data = data
                };
            }
            
            var token = new ProcessToken(global, _bindingMap);

            static async Task<(string @out, Node<Container> current)> ProcessAsync(Task<string> task, Node<Container> node) 
                => (await task, node);

            Task<(string @out, Node<Container> current)> Process(Node<Container> node) 
                => ProcessAsync(_serverModule.Execute(node.Current.Server, token), node);

            var check = _tree.Current.When.Check(token, _tree.Current);

            yield return Step(_tree, nameof(Container.When), check);

            if (!check.IsPassed)
                yield break;

            var tasks = Process(_tree).ToEnumerable().ToList();

            do
            {
                var (@out, current) = await tasks.TakeAny();
                var container = current.Current;

                token.SetOut(container.Id, @out);

                yield return Step(current, nameof(Container.Server), @out);

                foreach (var assert in container.Asserts)
                {
                    yield return Step(current, nameof(Container.Asserts), assert.Check(token, container));
                }

                token.AddPath(current);

                foreach (var child in current.Childrens.Where(token.CheckPath))
                {
                    var childCheck = child.Current.When.Check(token, child.Current);

                    yield return Step(child, nameof(Container.When), childCheck);

                    if (!childCheck.IsPassed)
                    {
                        token.AddPath(child);
                        continue;
                    }

                    tasks.Add(Process(child));
                }
            }
            while (tasks.Any());
        }
    }
}