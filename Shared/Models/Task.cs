using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }

        //Ref
        public Priority Priority { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
