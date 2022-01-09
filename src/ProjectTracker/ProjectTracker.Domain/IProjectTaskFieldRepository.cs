using ProjectTracker.Domain.Models;

using System.Linq;

namespace ProjectTracker.Domain
{
    /// <summary>
    /// Project's task's field repository interface
    /// </summary>
    public interface IProjectTaskFieldRepository
    {
        /// <summary>
        /// Gets all projects' tasks' fields
        /// </summary>
        /// <returns>all tasks' fields</returns>
        IQueryable<IProjectTaskField> GetAll();

        /// <summary>
        /// Gets task's field by specified composite key: taskId and fieldName
        /// </summary>
        /// <param name="taskId">Task Id</param>
        /// <param name="fieldName">Field name</param>
        /// <returns>task's field</returns>
        IProjectTaskField GetById(int taskId, string fieldName);

        /// <summary>Creates new task field and store it.</summary>
        /// <param name="input">new task field data</param>
        /// <returns>created task field</returns>
        IProjectTaskField Create(ProjectTaskFieldModel input);

        /// <summary>Updates existing task field and store it.</summary>
        /// <param name="input">task field new data</param>
        /// <returns>updated task field</returns>
        IProjectTaskField Update(ProjectTaskFieldModel input);

        /// <summary>
        /// Deletes task's field by specified composite key: taskId and fieldName
        /// </summary>
        /// <param name="taskId">Task Id</param>
        /// <param name="fieldName">Fiel dName</param>
        /// <returns>deleted object</returns>
        IProjectTaskField Delete(int taskId, string fieldName);
    }
}
