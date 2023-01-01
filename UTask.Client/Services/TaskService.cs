using MudBlazor.Utilities;
using System.Net.Http.Json;
using UTask.Client.Services.Contact;
using Task = Shared.Models.Task;
namespace UTask.Client.Services
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient _http;
        public TaskService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Task>> GetAllTasksAsync()
        {
            try
            {
                var allTasks = await _http.GetAsync("/api/task");

                if (allTasks.IsSuccessStatusCode)
                {
                    if (allTasks.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Task>();
                    }

                    return await allTasks.Content.ReadFromJsonAsync<IEnumerable<Task>>();
                }
                else
                {
                    var message = await allTasks.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {allTasks.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }



        }
    }
}
