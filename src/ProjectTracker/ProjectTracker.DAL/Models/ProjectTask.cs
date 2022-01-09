using ProjectTracker.Domain;

using System.Collections.Generic;

namespace ProjectTracker.DAL.Models
{
    /// <summary>
    /// A ProjectTask instance represents a project task entity.
    /// </summary>
    public class ProjectTask : IProjectTask
    {
        /// <summary>
        /// Task identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Project identifier
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Task name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Task status
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Task priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Project that this task belongs to
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Task's fields
        /// </summary>
        public ICollection<ProjectTaskField> Fields { get; set; }

        IEnumerable<IProjectTaskField> IProjectTask.Fields => Fields;
    }
}
