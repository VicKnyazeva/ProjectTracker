using System.Collections.Generic;

namespace ProjectTracker.Domain
{
    /// <summary>
    /// IProjectTask interface represents a project's task
    /// </summary>
    public interface IProjectTask : IEntity
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
        /// Task's fields
        /// </summary>
        public IEnumerable<IProjectTaskField> Fields { get; }
    }
}
