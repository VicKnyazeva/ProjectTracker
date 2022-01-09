using Microsoft.EntityFrameworkCore;

using ProjectTracker.DAL.Models;
using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;

using System;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectTracker.DAL
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectTrackerDbContext _dbc;
        public ProjectRepository(ProjectTrackerDbContext dbc)
        {
            _dbc = dbc;
        }

        private static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(IQueryable<TSource> source, ProjectSortOrder order, Expression<Func<TSource, TKey>> keySelector)
        {
            if (order == ProjectSortOrder.Ascending)
                return source.OrderBy(keySelector);
            else
                return source.OrderByDescending(keySelector);
        }

        public IQueryable<IProject> GetAll(ProjectFilterAndSort filter)
        {
            IQueryable<Project> query = _dbc.Projects.Include(p => p.Tasks);
            if (filter != null)
            {
                if (filter.Name != null)
                    query = query.Where(p => p.Name.Contains(filter.Name));
                if (filter.Status != null)
                    query = query.Where(p => p.Status == filter.Status.Value);
                if (filter.Priority != null)
                    query = query.Where(p => p.Priority == filter.Priority.Value);
                if (filter.Created != null)
                    query = query.Where(p => p.Created == filter.Created.Value);
                if (filter.Completed != null)
                    query = query.Where(p => p.Completed == filter.Completed.Value);

                switch (filter.Sort)
                {
                    default:
                        break;
                    case ProjectSort.Name:
                        query = OrderBy(query, filter.SortOrder, p => p.Name);
                        break;
                    case ProjectSort.Status:
                        query = OrderBy(query, filter.SortOrder, p => p.Status);
                        break;
                    case ProjectSort.Priority:
                        query = OrderBy(query, filter.SortOrder, p => p.Priority);
                        break;
                    case ProjectSort.Created:
                        query = OrderBy(query, filter.SortOrder, p => p.Created);
                        break;
                    case ProjectSort.Completed:
                        query = OrderBy(query, filter.SortOrder, p => p.Completed);
                        break;
                }
            }
            return query;
        }

        public IProject GetById(int id)
        {
            return _dbc.Projects.FirstOrDefault(p => p.Id == id);
        }

        public IProject Create(ProjectCreateModel input)
        {
            Project result = new Project()
            {
                Completed = input.Completed,
                Created = input.Created,
                Description = input.Description,
                Name = input.Name,
                Priority = input.Priority,
                Status = input.Status, 
            };
            _dbc.Projects.Add(result);
            _dbc.SaveChanges();
            return result;
        }

        public IProject Update(ProjectEditModel input)
        {
            var entity = _dbc.Projects.FirstOrDefault(i => i.Id == input.Id);
            if (entity != null)
            {
                entity.Completed = input.Completed;
                entity.Created = input.Created;
                entity.Description = input.Description;
                entity.Name = input.Name;
                entity.Priority = input.Priority;
                entity.Status = input.Status;

                _dbc.SaveChanges();
            }
            return entity;
        }

        public IProject Delete(int id)
        {
            var entity = _dbc.Projects.FirstOrDefault(i => i.Id == id);
            if (entity != null)
            {
                _dbc.Remove(entity);
                _dbc.SaveChanges();
            }
            return entity;
        }
    }
}
