using ProjectTracker.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Domain
{
    /// <summary>
    /// Interface for Project repository
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// Gets all projects with sorting applied, that satisfied filter
        /// </summary>
        /// <param name="filter">Filter and sorting settings</param>
        /// <returns>all projects</returns>
        IQueryable<IProject> GetAll(ProjectFilterAndSort filter);

        /// <summary>
        /// Gets project by specified Id
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns>project with corresponding Id</returns>
        IProject GetById(int id);

        /// <summary>Creates new project and store it</summary>
        /// <param name="input">new project data</param>
        /// <returns>created project</returns>
        IProject Create(ProjectCreateModel input);

        /// <summary>Updates existing project and store it</summary>
        /// <param name="input">project new data</param>
        /// <returns>updated project</returns>
        IProject Update(ProjectEditModel input);

        /// <summary>
        /// Deletes the project with the specified ID
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns>returns deleted object</returns>
        IProject Delete(int id);
    }
}
