
using ProjectTracker.DAL.Models;
using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;

using System.Linq;

namespace ProjectTracker.DAL
{
    /// <summary>
    /// A ProjectTaskFieldRepository instance represents a repository of project' tasks' fields entities.
    /// </summary>
    public class ProjectTaskFieldRepository : IProjectTaskFieldRepository
    {
        private readonly ProjectTrackerDbContext _dbc;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTaskFieldRepository"/> class
        /// </summary>
        /// <param name="dbc">Database context</param>
        public ProjectTaskFieldRepository(ProjectTrackerDbContext dbc)
        {
            _dbc = dbc;
        }

        /// <summary>
        /// Gets all projects' tasks' fields
        /// </summary>
        /// <returns>all tasks' fields</returns>
        public IQueryable<IProjectTaskField> GetAll()
        {
            return _dbc.ProjectTaskFields;
        }

        /// <summary>
        /// Gets task's field by specified composite key: taskId and fieldName
        /// </summary>
        /// <param name="taskId">Task Id</param>
        /// <param name="fieldName">Field name</param>
        /// <returns>task's field</returns>
        public IProjectTaskField GetById(int taskId, string fieldName)
        {
            return _dbc.ProjectTaskFields.FirstOrDefault(f => f.TaskId == taskId && f.Name == fieldName);
        }

        /// <summary>
        /// Creates task's field and stores it to database
        /// </summary>
        /// <param name="input">New data for task's field</param>
        /// <returns>created field</returns>
        public IProjectTaskField Create(ProjectTaskFieldModel input)
        {
            ProjectTaskField result = new ProjectTaskField()
            {
                TaskId = input.TaskId,
                Name = input.Name,
                Value = input.Value,
            };
            _dbc.ProjectTaskFields.Add(result);
            _dbc.SaveChanges();
            return result;
        }

        /// <summary>
        /// Updates task's field
        /// </summary>
        /// <param name="input">Updated data for task's field</param>
        /// <returns>Updated task's field/returns>
        public IProjectTaskField Update(ProjectTaskFieldModel input)
        {
            var entity = _dbc.ProjectTaskFields.FirstOrDefault(f => f.TaskId == input.TaskId && f.Name == input.Name);
            if (entity != null)
            {
                entity.Value = input.Value;
                _dbc.SaveChanges();
            }
            return entity;
        }

        /// <summary>
        /// Deletes task's field by specified composite key: taskId and fieldName
        /// </summary>
        /// <param name="taskId">Task Id</param>
        /// <param name="fieldName">Fiel dName</param>
        /// <returns>deleted object</returns>
        public IProjectTaskField Delete(int taskId, string fieldName)
        {
            var entity = _dbc.ProjectTaskFields.FirstOrDefault(f => f.TaskId == taskId && f.Name == fieldName);
            if (entity != null)
            {
                _dbc.Remove(entity);
                _dbc.SaveChanges();
            }
            return entity;
        }
    }
}
