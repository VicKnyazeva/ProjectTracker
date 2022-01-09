using ProjectTracker.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Domain
{
    public interface IProjectRepository
    {
        IQueryable<IProject> GetAll(ProjectFilterAndSort filter);
        
        IProject GetById(int id);

        /// <summary>Creates new project and store it.</summary>
        /// <param name="input">new project data</param>
        /// <returns>created project</returns>
        IProject Create(ProjectCreateModel input);

        /// <summary>Updates existing project and store it.</summary>
        /// <param name="input">project new data</param>
        /// <returns>updated project</returns>
        IProject Update(ProjectEditModel input);
        
        IProject Delete(int id);
    }
}
