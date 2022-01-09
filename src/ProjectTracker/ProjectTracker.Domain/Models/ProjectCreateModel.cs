using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Domain.Models
{
    public class ProjectCreateModel
    {
        [Required, StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public DateTime? Started { get; set; }

        public DateTime? Completed { get; set; }

        public ProjectStatus Status { get; set; }

        /// <summary>Project priority</summary>
        [Range(0, 1_000_000)]
        public int Priority { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
