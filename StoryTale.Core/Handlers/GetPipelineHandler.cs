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

            rootId: 2
            
            servers:

            -   
                id: 2
                parentId: 1
                uri: http://192.168.5.10:19081/iRIS.InsuranceApp/iRIS.InsuranceApp.CoefficientService.Host/api/coefficient/get
                httpMethod: Post
                in: 
                -
                    tablename: !globalbind
                        path: tablename
                    parameters:
                    -
                        attributeid: !globalbind
                            path: attributeid
                        attributevalue: !globalbind
                            path: attributevalue

...";

            return Task.FromResult(document);
        }
    }

    public class GetPipelineRequest : IRequest<string>
    {
        public string Name { get; set; }
    }
}