using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Domain.Models
{
    public class ProjectTaskFieldModel
    {
        [Required]
        public int TaskId { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Value { get; set; }
    }
}
