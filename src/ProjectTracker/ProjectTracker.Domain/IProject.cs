using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Domain
{
    public interface IProject : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Completed { get; set; }

        public ProjectStatus Status { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public IEnumerable<IProjectTask> Tasks { get; }
    }
}
