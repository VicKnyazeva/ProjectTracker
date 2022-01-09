using System;

namespace ProjectTracker.Domain
{
    /// <summary>
    /// A ProjectFilterAndSort instance allows to apply filter and sort by project fields
    /// </summary>
    public class ProjectFilterAndSort
    {
        /// <summary>
        /// Project name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Project status
        /// </summary>
        public ProjectStatus? Status { get; set; }

        /// <summary>
        /// Project start date
        /// </summary>
        public DateTime? Started { get; set; }

        /// <summary>
        /// Project completion date
        /// </summary>
        public DateTime? Completed { get; set; }

        /// <summary>
        /// Project priority
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Project sort fields
        /// </summary>
        public ProjectSort? Sort { get; set; }

        /// <summary>
        /// Project sort order
        /// </summary>
        public ProjectSortOrder SortOrder { get; set; } = ProjectSortOrder.Ascending;
    }
}
