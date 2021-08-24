using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;
using todopractica1.Functions.Entities;

namespace todopractica1.Functions.Functions
{
    public static class ScheduledFunction
    {
        [FunctionName("ScheduledFunction")]
        public static async Task Run(
        [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer,
        [Table("todo", Connection = "AzureWebJobsStorage")] CloudTable todoTable,
        ILogger log)
        {
            log.LogInformation($"Deleting completed function executed at: {DateTime.Now}");

            TableQuery<TodoEntity> query = new TableQuery<TodoEntity>();
            TableQuerySegment<TodoEntity> completedTodos = await todoTable.ExecuteQuerySegmentedAsync(query, null);
            int deleted = 0;

            foreach (TodoEntity completedTodo in completedTodos)
            {
                if (completedTodo.IsCompleted.Equals(true))
                {
                    await todoTable.ExecuteAsync(TableOperation.Delete(completedTodo));
                    deleted++;
                }
            }

            log.LogInformation($"Deleted: {deleted} items at: {DateTime.Now}");
        }
    }
}
