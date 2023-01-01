using Microsoft.EntityFrameworkCore;
using Shared.Models;
using UTask.Server.Data;
using UTask.Server.Repos.Contact;

namespace UTask.Server.Repos
{
    public class TaskRepository : ITaskReposiotry
    {
        private readonly UTaskDbContext _context;

        public TaskRepository(UTaskDbContext context)
        {
            _context = context;
        }

        public async Task<Shared.Models.Task> CreateTaskAsync(Shared.Models.Task task)
        {
            var createdTask = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return createdTask.Entity;

        }

        public async Task<IEnumerable<Shared.Models.Task>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .AsNoTracking()
                .Include(t => t.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Shared.Models.Task>> GetTaskByCategoryAsync(Category category)
        {
            return await _context.Tasks
                .AsNoTracking()
                .Include(t => t.Category)
                .Where(t => t.CategoryId == category.Id)
                .ToListAsync();
        }

        public async Task<Shared.Models.Task> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Shared.Models.Task>> GetTaskByPriorityAsync(Priority priority)
        {
            return await _context.Tasks
                .AsNoTracking()
               .Include(t => t.Category)
               .Where(t => t.Priority == priority)
               .ToListAsync();
        }
    }
}
