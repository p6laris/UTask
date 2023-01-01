using Microsoft.AspNetCore.Mvc;
using UTask.Server.Repos;
using UTask.Server.Repos.Contact;

namespace UTask.Server.Controllers
{
    class Panda
    {
        int y;
        public Panda(int x)
        {
            y = x;
        }
    }

    [ApiController]
    [Route("/api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskReposiotry _repo;

        public TaskController(ITaskReposiotry repo) 
        {
            _repo = repo;
            
        }
        /// <summary>
        /// Gets all tasks
        /// </summary>
        /// <returns>Task</returns>
        
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Shared.Models.Task>>> GetAllTasks()
        {
            try
            {
                var allTasks = await _repo.GetAllTasksAsync();

                if(allTasks is not null)
                {
                    return Ok(allTasks);
                }

                return NoContent();
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the database");
            }
        }
    }
}
