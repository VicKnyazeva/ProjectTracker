using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Domain.Models
{
    /// <summary>
    /// Represents model for a new Project entity
    /// </summary>
    public class ProjectCreateModel
    {
        /// <summary>
        /// Project name
        /// </summary>
        [Required, StringLength(100, MinimumLength = 1)]
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
        [Range(0, 1_000_000)]
        public int Priority { get; set; }

        /// <summary>
        /// Project description
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }
    }
}
