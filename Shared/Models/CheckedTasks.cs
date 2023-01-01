using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Shared.Models.Task;

namespace Shared.Models
{
    public class CheckedTasks
    {
        public int Id { get; set; }

        public Task? Task { get; set; } 
        public int TaskId { get; set; }
    }
}
