using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTale.Core.Extensions
{
    public static class TaskExtensions
    {
        public static async Task<T> TakeAny<T>(this IList<Task<T>> tasks)
        {
            var task = await Task.WhenAny(tasks);

            tasks.Remove(task);

            return await task;
        }
    }
}