using Shared.Models;

namespace UTask.Server.Repos.Contact
{
    public interface ITaskReposiotry
    {
        Task<IEnumerable<Shared.Models.Task>> GetAllTasksAsync();
        Task<Shared.Models.Task> GetTaskByIdAsync(int id);
        Task<IEnumerable<Shared.Models.Task>> GetTaskByPriorityAsync(Priority priority);
        Task<IEnumerable<Shared.Models.Task>> GetTaskByCategoryAsync(Category category);
        Task<Shared.Models.Task> CreateTaskAsync(Shared.Models.Task task);
    }
}
