using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Domain.Models
{
    public class ProjectTaskCreateModel
    {
        [Required]
        public int ProjectId { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public TaskStatus Status { get; set; }

        [Range(0, 1_000_000)]
        public int Priority { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
