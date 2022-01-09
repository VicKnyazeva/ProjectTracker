using System;

namespace ProjectTracker.Domain
{
    public class ProjectFilterAndSort
    {
        public string Name { get; set; }

        public ProjectStatus? Status { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Completed { get; set; }

        public int? Priority { get; set; }

        public ProjectSort? Sort { get; set; }

        public ProjectSortOrder SortOrder { get; set; } = ProjectSortOrder.Ascending;
    }
}
