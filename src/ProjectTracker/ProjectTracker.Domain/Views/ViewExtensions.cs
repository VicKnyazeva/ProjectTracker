using System.Collections.Generic;
using System.Linq;

namespace ProjectTracker.Domain.Views
{
    public static class ViewExtensions
    {
        public static ProjectView ToView(this IProject source)
        {
            if (source == null)
                return null;

            return new ProjectView
            {
                Id = source.Id,
                Status = source.Status,
                Started = source.Started,
                Completed = source.Completed,
                Description = source.Description,
                Name = source.Name,
                Priority = source.Priority,
                Tasks = source.Tasks.ToViews()?.ToList(),
            };
        }

        public static IEnumerable<ProjectView> ToViews(this IEnumerable<IProject> source)
        {
            return source?.Select(source => ToView(source));
        }

        public static ProjectTaskView ToView(this IProjectTask source)
        {
            if (source == null)
                return null;

            return new ProjectTaskView
            {
                Id = source.Id,
                Status = source.Status,
                Description = source.Description,
                Name = source.Name,
                Priority = source.Priority,
                ProjectId = source.ProjectId,
                Fields = source.Fields.ToViews()?.ToList(),
            };
        }

        public static IEnumerable<ProjectTaskView> ToViews(this IEnumerable<IProjectTask> source)
        {
            return source?.Select(source => ToView(source));
        }

        public static ProjectTaskFieldView ToView(this IProjectTaskField source)
        {
            if (source == null)
                return null;

            return new ProjectTaskFieldView
            {
                TaskId = source.TaskId,
                Name = source.Name,
                Value = source.Value,
            };
        }

        public static IEnumerable<ProjectTaskFieldView> ToViews(this IEnumerable<IProjectTaskField> source)
        {
            return source?.Select(source => ToView(source));
        }
    }
}
