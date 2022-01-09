namespace ProjectTracker.Domain.Models
{
    /// <summary>
    /// Represents model for an updated Task
    /// </summary>
    public class ProjectTaskEditModel : ProjectTaskCreateModel
    {
        /// <summary>
        /// Task identifier
        /// </summary>
        public int Id { get; set; }
    }
}
