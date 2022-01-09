using System;
using System.Collections.Generic;

namespace ProjectTracker.Domain.Views
{
    public class ProjectView : IProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Completed { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }

        public List<ProjectTaskView> Tasks { get; set; }

        IEnumerable<IProjectTask> IProject.Tasks { get => Tasks; }
    }
}
