using Microsoft.EntityFrameworkCore;

using ProjectTracker.DAL.Models;
using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;

using System.Linq;

namespace ProjectTracker.DAL
{
    /// <summary>
    /// A ProjectTaskRepository instance represents a repository of project' tasks entities.
    /// </summary>
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly ProjectTrackerDbContext _dbc;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTaskRepository"/> class
        /// </summary>
        /// <param name="dbc">Database context</param>
        public ProjectTaskRepository(ProjectTrackerDbContext dbc)
        {
            _dbc = dbc;
        }

        /// <summary>
        /// Gets all projects' tasks
        /// </summary>
        /// <returns>all tasks with their fields</returns>
        public IQueryable<IProjectTask> GetAll()
        {
            return _dbc.ProjectTasks.Include(t => t.Fields);
        }

        /// <summary>
        /// Gets task by specified Id
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns>task with its fields</returns>
        public IProjectTask GetById(int id)
        {
            return _dbc.ProjectTasks.Include(t=>t.Fields).FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Creates new task and stores it to database
        /// </summary>
        /// <param name="input">New data for task</param>
        /// <returns>created task</returns>
        public IProjectTask Create(ProjectTaskCreateModel input)
        {
            ProjectTask result = new ProjectTask()
            {
                ProjectId = input.ProjectId,
                Description = input.Description,
                Name = input.Name,
                Priority = input.Priority,
                Status = input.Status, 
            };
            _dbc.ProjectTasks.Add(result);
            _dbc.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates existing task and stores it 
        /// </summary>
        /// <param name="input">Updated data for task</param>
        /// <returns>updated task</returns>
        public IProjectTask Update(ProjectTaskEditModel input)
        {
            var entity = _dbc.ProjectTasks.FirstOrDefault(p => p.Id == input.Id);
            if (entity != null)
            {
                entity.ProjectId = input.ProjectId;
                entity.Description = input.Description;
                entity.Name = input.Name;
                entity.Priority = input.Priority;
                entity.Status = input.Status;

                _dbc.SaveChanges();
            }
            return entity;
        }

        /// <summary>
        /// Deletes task by specified task id
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns>deleted object</returns>
        public IProjectTask Delete(int id)
        {
            var entity = _dbc.ProjectTasks.FirstOrDefault(p => p.Id == id);
            if (entity != null)
            {
                _dbc.Remove(entity);
                _dbc.SaveChanges();
            }
            return entity;
        }
    }
}
