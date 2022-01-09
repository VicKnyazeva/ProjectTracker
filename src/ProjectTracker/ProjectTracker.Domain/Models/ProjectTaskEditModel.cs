namespace ProjectTracker.Domain.Models
{
    /// <summary>
    /// Represents model for an updated task
    /// </summary>
    public class ProjectTaskEditModel : ProjectTaskCreateModel
    {
        /// <summary>
        /// Task identifier
        /// </summary>
        public int Id { get; set; }
    }
}
