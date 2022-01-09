using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Domain.Models
{
    /// <summary>
    /// Represents model for a new Project's Task's Field
    /// </summary>
    public class ProjectTaskFieldModel
    {
        /// <summary>
        /// Task identifier
        /// </summary>
        [Required]
        public int TaskId { get; set; }

        /// <summary>
        /// Field name
        /// </summary>
        [Required, StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Field value
        /// </summary>
        [StringLength(500)]
        public string Value { get; set; }
    }
}
