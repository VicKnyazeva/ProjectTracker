using ProjectTracker.Domain.Models;

using System.Linq;

namespace ProjectTracker.Domain
{
    public interface IProjectTaskFieldRepository
    {
        IQueryable<IProjectTaskField> GetAll();

        IProjectTaskField GetById(int taskId, string fieldName);

        /// <summary>Creates new task field and store it.</summary>
        /// <param name="input">new task field data</param>
        /// <returns>created task field</returns>
        IProjectTaskField Create(ProjectTaskFieldModel input);

        /// <summary>Updates existing task field and store it.</summary>
        /// <param name="input">task field new data</param>
        /// <returns>updated task field</returns>
        IProjectTaskField Update(ProjectTaskFieldModel input);

        IProjectTaskField Delete(int taskId, string fieldName);
    }
}
