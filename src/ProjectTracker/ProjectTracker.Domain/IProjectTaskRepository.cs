using ProjectTracker.Domain.Models;

using System.Linq;

namespace ProjectTracker.Domain
{
    public interface IProjectTaskRepository
    {
        IQueryable<IProjectTask> GetAll();

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
