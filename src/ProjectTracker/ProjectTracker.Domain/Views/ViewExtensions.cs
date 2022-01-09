using System.Collections.Generic;
using System.Linq;

namespace ProjectTracker.Domain.Views
{
    /// <summary>Extension class that implements a set of maps methods</summary>
    public static class ViewExtensions
    {
        /// <summary>
        /// Maps object that implements interface <see cref="IProject"/> to object of the <see cref="ProjectView"/> class.
        /// </summary>
        /// <param name="source">Source object or null</param>
        /// <returns>Object mappedd from source or null</returns>
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

        /// <summary>
        /// Maps enumeration of objects that implement interface <see cref="IProject"/> to enumeration of objects of the <see cref="ProjectView"/> class.
        /// </summary>
        /// <param name="source">Source or null</param>
        /// <returns>Object mappedd from source or null</returns>
        public static IEnumerable<ProjectView> ToViews(this IEnumerable<IProject> source)
        {
            return source?.Select(source => ToView(source));
        }

        /// <summary>
        /// Maps object that implements interface <see cref="IProjectTask"/> to object of the <see cref="ProjectTaskView"/> class.
        /// </summary>
        /// <param name="source">Source object or null</param>
        /// <returns>Object mappedd from source or null</returns>
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

        /// <summary>
        /// Maps enumeration of objects that implement interface <see cref="IProjectTask"/> to enumeration of objects of the <see cref="ProjectTaskView"/> class.
        /// </summary>
        /// <param name="source">Source or null</param>
        /// <returns>Object mappedd from source or null</returns>
        public static IEnumerable<ProjectTaskView> ToViews(this IEnumerable<IProjectTask> source)
        {
            return source?.Select(source => ToView(source));
        }

        /// <summary>
        /// Maps object that implements interface <see cref="IProjectTaskField"/> to object of the <see cref="ProjectTaskFieldView"/> class.
        /// </summary>
        /// <param name="source">Source object or null</param>
        /// <returns>Object mappedd from source or null</returns>
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

        /// <summary>
        /// Maps enumeration of objects that implement interface <see cref="IProjectTaskField"/> to enumeration of objects of the <see cref="ProjectTaskFieldView"/> class.
        /// </summary>
        /// <param name="source">Source or null</param>
        /// <returns>Object mappedd from source or null</returns>
        public static IEnumerable<ProjectTaskFieldView> ToViews(this IEnumerable<IProjectTaskField> source)
        {
            return source?.Select(source => ToView(source));
        }
    }
}
