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

            rootId: 1
            
            containers:
            -   
                id: 1
                name: Сервер коэффициентов
                when:
                    isGenerateException: yes
                    name: Test
                    condition:
                        in:
                            x: !!int 17
                            y: !globalbind
                                path: attribute.id
                        expr: int(x) > int(y)
                server: 
                    uri: http://192.168.5.10:19081/iRIS.InsuranceApp/iRIS.InsuranceApp.CoefficientService.Host/api/coefficient/get
                    httpMethod: Post
                    in: 
                    -
                        tablename: !globalbind
                            path: tablename
                        parameters:
                        -
                            attributeid: !globalbind
                                path: attribute.id
                            attributevalue: !globalbind
                                path: attribute.value
                asserts:
                -
                    isGenerateException: no
                    name: Test
                    condition:
                        in:
                            x: !!int 17
                            y: !globalbind
                                path: attribute.id
                        expr: int(x) < int(y)
            -   
                id: 2
                parentIds: [1]
                name: Сервер коэффициентов 2
                server: 
                    uri: http://192.168.5.10:19081/iRIS.InsuranceApp/iRIS.InsuranceApp.CoefficientService.Host/api/coefficient/get
                    httpMethod: Post
                    in: 
                    -
                        tablename: !globalbind
                            path: tablename
                        parameters:
                        -
                            attributeid: !globalbind
                                path: attribute.id
                            attributevalue: !globalbind
                                path: attribute.value
            -   
                id: 3
                parentIds: [1]
                name: Сервер коэффициентов 3
                server: 
                    uri: http://192.168.5.10:19081/iRIS.InsuranceApp/iRIS.InsuranceApp.CoefficientService.Host/api/coefficient/get
                    httpMethod: Post
                    in: 
                    -
                        tablename: !globalbind
                            path: tablename
                        parameters:
                        -
                            attributeid: !globalbind
                                path: attribute.id
                            attributevalue: !globalbind
                                path: attribute.value
            -   
                id: 4
                parentIds: [2, 3]
                name: Сервер коэффициентов 4
                server: 
                    uri: http://192.168.5.10:19081/iRIS.InsuranceApp/iRIS.InsuranceApp.CoefficientService.Host/api/coefficient/get
                    httpMethod: Post
                    in: 
                    -
                        tablename: !globalbind
                            path: tablename
                        parameters:
                        -
                            attributeid: !globalbind
                                path: attribute.id
                            attributevalue: !globalbind
                                path: attribute.value
            -   
                id: 5
                parentIds: [4]
                name: Сервер коэффициентов 5
                server: 
                    uri: http://192.168.5.10:19081/iRIS.InsuranceApp/iRIS.InsuranceApp.CoefficientService.Host/api/coefficient/get
                    httpMethod: Post
                    in: 
                    -
                        tablename: !globalbind
                            path: tablename
                        parameters:
                        -
                            attributeid: !globalbind
                                path: attribute.id
                            attributevalue: !globalbind
                                path: attribute.value
...";

            return Task.FromResult(document);
        }
    }

    public class GetPipelineRequest : IRequest<string>
    {
        public string Name { get; set; }
    }
}