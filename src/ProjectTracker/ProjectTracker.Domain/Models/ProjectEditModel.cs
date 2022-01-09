namespace ProjectTracker.Domain.Models
{
    /// <summary>
    /// Represents model for an updated project
    /// </summary>
    public class ProjectEditModel: ProjectCreateModel
    {
        /// <summary>
        /// Project identifier
        /// </summary>
        public int Id { get; set; }
    }
}
