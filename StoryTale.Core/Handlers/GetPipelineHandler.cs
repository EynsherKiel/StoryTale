using StoryTale.Core.Database;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StoryTale.Core.Handlers
{
    public class GetPipelineHandler : IRequestHandler<GetPipelineRequest, string>
    {
        private readonly Queries _queries;

        public GetPipelineHandler(Queries queries)
        {
            _queries = queries;
        }

        public Task<string> Handle(GetPipelineRequest request, CancellationToken cancellationToken)
        {
            // getting from database
            var document = @"---
            global: 
                name: null
                date: null

            rootId: 1
            
            servers:
            -   
                id: 1
                parentId: null
                uri: https://localhost:44338/api/simple/hello
                httpMethod: Get
                in: 
                    date: {global date}
                out:
                    carid: null
            -   
                id: 2
                parentId: 1
                uri: https://localhost:44338/api/simple/test
                httpMethod: Post
                in:
                    carId: {1 carid}
                    date: {global date}
                out:
                    carId: null
                    date: null
            -   
                id: 3
                parentId: 2
                uri: https://localhost:44338/api/simple/test
                httpMethod: Post
                in:
                    carId: {1 carid}
                    date: {global date}
                out:
                    carId: null
                    date: null
            -   
                id: 4
                parentId: 3
                uri: https://localhost:44338/api/simple/test
                httpMethod: Post
                in:
                    carId: {1 carid}
                    date: {global date}
                out:
                    carId: null
                    date: null
            -   
                id: 5
                parentId: 4
                uri: https://localhost:44338/api/simple/test
                httpMethod: Post
                in:
                    carId: {1 carid}
                    date: {global date}
                out:
                    carId: null
                    date: null
            -   
                id: 6
                parentId: 5
                uri: https://localhost:44338/api/simple/test
                httpMethod: Post
                in:
                    carId: {1 carid}
                    date: {global date}
                out:
                    carId: null
                    date: null
            -   
                id: 7
                parentId: 6
                uri: https://localhost:44338/api/simple/test
                httpMethod: Post
                in:
                    carId: {1 carid}
                    date: {global date}
                out:
                    carId: null
                    date: null
            -   
                id: 8
                parentId: 7
                uri: https://localhost:44338/api/simple/test
                httpMethod: Post
                in:
                    carId: {1 carid}
                    date: {global date}
                out:
                    carId: null
                    date: null
...";               

            return Task.FromResult(document);
        }
    }

    public class GetPipelineRequest : IRequest<string>
    {
        public string Name { get; set; }
    }
}