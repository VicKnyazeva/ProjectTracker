using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Domain.Models
{
    /// <summary>
    /// Represents model for a new project task
    /// </summary>
    public class ProjectTaskCreateModel
    {
        /// <summary>
        /// Project identifier
        /// </summary>
        [Required]
        public int ProjectId { get; set; }

        /// <summary>
        /// Task name
        /// </summary>
        [Required, StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Task status
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Task priority
        /// </summary>
        [Range(0, 1_000_000)]
        public int Priority { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }
    }
}
