using System;
using System.Collections.Generic;

namespace ProjectTracker.Domain
{
    /// <summary>
    /// IProject interface represents a project
    /// </summary>
    public interface IProject : IEntity
    {
        /// <summary>
        /// Project Identifier
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
        public IEnumerable<IProjectTask> Tasks { get; }
    }
}
