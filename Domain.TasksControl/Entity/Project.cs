using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TasksControl.Entity
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Author { get; set; }

        public int StatusProject {  get; set; }
        public DateTime DeadLine { get; set; }
    }
}
