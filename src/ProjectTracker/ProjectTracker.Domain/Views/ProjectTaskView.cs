using System;
using System.Collections.Generic;

namespace ProjectTracker.Domain.Views
{
    /// <summary>
    /// ProjectTaskView instance represents project's task DTO
    /// </summary>
    public class ProjectTaskView : IProjectTask
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
        public List<ProjectTaskFieldView> Fields { get; set; }
        IEnumerable<IProjectTaskField> IProjectTask.Fields => throw new NotImplementedException();
    }
}
