
using ProjectTracker.DAL.Models;
using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;

using System.Linq;

namespace ProjectTracker.DAL
{
    public class ProjectTaskFieldRepository : IProjectTaskFieldRepository
    {
        private readonly ProjectTrackerDbContext _dbc;
        public ProjectTaskFieldRepository(ProjectTrackerDbContext dbc)
        {
            _dbc = dbc;
        }

        public IQueryable<IProjectTaskField> GetAll()
        {
            return _dbc.ProjectTaskFields;
        }

        public IProjectTaskField GetById(int taskId, string fieldName)
        {
            return _dbc.ProjectTaskFields.FirstOrDefault(f => f.TaskId == taskId && f.Name == fieldName);
        }

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
