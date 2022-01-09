namespace ProjectTracker.Domain.Views
{
    /// <summary>
    /// ProjectTaskFieldView instance represents project's task's field DTO
    /// </summary>
    public class ProjectTaskFieldView : IProjectTaskField
    {
        /// <summary>
        /// Task identifier
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Field name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Field vaue
        /// </summary>
        public string Value { get; set; }
    }
}
