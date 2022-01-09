using ProjectTracker.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTracker.DAL.Models
{
    /// <summary>
    /// A ProjectTaskField instance represents a project's task's field entity.
    /// </summary>
    public class ProjectTaskField : IProjectTaskField
    {
        /// <summary>
        /// Task identifier
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskId { get; set; }

        /// <summary>
        /// Field name
        /// </summary>
        [Key]
        public string Name { get; set; }

        /// <summary>
        /// Field vaue
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Task which this field belongs to
        /// </summary>
        public ProjectTask Task { get; set; }
    }
}
