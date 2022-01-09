using ProjectTracker.Domain;

using System;
using System.Collections.Generic;

namespace ProjectTracker.DAL.Models
{
    public class Project : IProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Completed { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }

        IEnumerable<IProjectTask> IProject.Tasks => Tasks;
    }
}
