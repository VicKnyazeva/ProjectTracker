using System;

namespace ProjectTracker.Domain
{
    //WIll be a plus to have an ability to filter and sort projects with various methods
    //(start at, end at, range, exact value, etc.) and by various fields (start date, priority, etc.)
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
