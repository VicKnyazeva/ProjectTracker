using ProjectTracker.Domain.Models;

using System.Linq;

namespace ProjectTracker.Domain
{
    /// <summary>
    /// Project's task repository interface
    /// </summary>
    public interface IProjectTaskRepository
    {
        /// <summary>
        /// Gets all projects' tasks
        /// </summary>
        /// <returns>all tasks with their fields</returns>
        IQueryable<IProjectTask> GetAll();

        /// <summary>
        /// Gets task by specified Id
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns>task with its fields</returns>
        IProjectTask GetById(int id);

        /// <summary>Creates new task and store it.</summary>
        /// <param name="input">new task data</param>
        /// <returns>created task</returns>
        IProjectTask Create(ProjectTaskCreateModel input);

        /// <summary>Updates existing task and store it.</summary>
        /// <param name="input">task new data</param>
        /// <returns>updated task</returns>
        IProjectTask Update(ProjectTaskEditModel input);

        /// <summary>
        /// Deletes Task by specified Id
        /// </summary>
        /// <param name="id">Tesk id</param>
        /// <returns>returns deleted object</returns>
        IProjectTask Delete(int id);
    }
}
