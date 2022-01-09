using Microsoft.EntityFrameworkCore;

using ProjectTracker.DAL.Models;
using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.DAL
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly ProjectTrackerDbContext _dbc;
        public ProjectTaskRepository(ProjectTrackerDbContext dbc)
        {
            _dbc = dbc;
        }

        public IQueryable<IProjectTask> GetAll()
        {
            return _dbc.ProjectTasks.Include(t => t.Fields);
        }

        public IProjectTask GetById(int id)
        {
            return _dbc.ProjectTasks.Include(t=>t.Fields).FirstOrDefault(t => t.Id == id);
        }

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
