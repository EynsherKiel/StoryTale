using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;

namespace StoryTale.Core.Services
{
    public interface IServiceInvoker
    {
        Task<string> Execute(Server server, JToken @in);
    }
}