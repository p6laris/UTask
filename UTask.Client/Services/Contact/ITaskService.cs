using Task = Shared.Models.Task;

namespace UTask.Client.Services.Contact
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetAllTasksAsync();

    }
}
