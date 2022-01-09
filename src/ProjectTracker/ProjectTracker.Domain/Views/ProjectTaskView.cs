using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Domain.Views
{
    public class ProjectTaskView : IProjectTask
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public int Priority { get; set; }

        public List<ProjectTaskFieldView> Fields { get; set; }
        IEnumerable<IProjectTaskField> IProjectTask.Fields => throw new NotImplementedException();
    }
}
