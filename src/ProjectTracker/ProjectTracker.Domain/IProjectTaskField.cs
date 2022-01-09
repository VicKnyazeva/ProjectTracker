namespace ProjectTracker.Domain
{
    /// <summary>
    /// IProjectTaskField interface represents a project's task's field.
    /// </summary>
    public interface IProjectTaskField : IEntity
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
