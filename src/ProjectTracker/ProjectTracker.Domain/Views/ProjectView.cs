using System;
using System.Collections.Generic;

namespace ProjectTracker.Domain.Views
{
    /// <summary>
    /// ProjectView instance represents project DTO
    /// </summary>
    public class ProjectView : IProject
    {
        /// <summary>
        /// Project Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Project name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Project start date
        /// </summary>
        public DateTime? Started { get; set; }

        /// <summary>
        /// Project completion date
        /// </summary>
        public DateTime? Completed { get; set; }

        /// <summary>
        /// Project status
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// Project priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Project description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Project's tasks
        /// </summary>
        public List<ProjectTaskView> Tasks { get; set; }

        IEnumerable<IProjectTask> IProject.Tasks { get => Tasks; }
    }
}
