using Microsoft.EntityFrameworkCore;

using ProjectTracker.DAL.Models;
using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;

using System;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectTracker.DAL
{
    /// <summary>
    /// A ProjectRepository instance represents a repository of project entities.
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectTrackerDbContext _dbc;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRepository"/> class
        /// </summary>
        /// <param name="dbc">Database context</param>
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

        /// <summary>
        /// Gets all projects with sorting applied, that satisfied filter
        /// </summary>
        /// <param name="filter">Filter and sorting settings</param>
        /// <returns>all projects</returns>
        public IQueryable<IProject> GetAll(ProjectFilterAndSort filter)
        {
            IQueryable<Project> query = _dbc.Projects.Include(p => p.Tasks).ThenInclude(p => p.Fields);
            if (filter != null)
            {
                if (filter.Name != null)
                    query = query.Where(p => p.Name.Contains(filter.Name));
                if (filter.Status != null)
                    query = query.Where(p => p.Status == filter.Status.Value);
                if (filter.Priority != null)
                    query = query.Where(p => p.Priority == filter.Priority.Value);
                if (filter.Started != null)
                    query = query.Where(p => p.Started == filter.Started.Value);
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
                        query = OrderBy(query, filter.SortOrder, p => p.Started);
                        break;
                    case ProjectSort.Completed:
                        query = OrderBy(query, filter.SortOrder, p => p.Completed);
                        break;
                }
            }
            return query;
        }

        /// <summary>
        /// Gets project by specified Id
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns>project with corresponding Id</returns>
        public IProject GetById(int id)
        {
            return _dbc.Projects.Include(p => p.Tasks).ThenInclude(p => p.Fields).FirstOrDefault(p => p.Id == id);
        }

        /// <summary>Creates new project and stores it to database</summary>
        /// <param name="input">new project data</param>
        /// <returns>created project</returns>
        public IProject Create(ProjectCreateModel input)
        {
            Project result = new Project()
            {
                Completed = input.Completed,
                Started = input.Started,
                Description = input.Description,
                Name = input.Name,
                Priority = input.Priority,
                Status = input.Status,
            };
            _dbc.Projects.Add(result);
            _dbc.SaveChanges();
            return result;
        }

        /// <summary>Updates existing project and stores it</summary>
        /// <param name="input">project updated data</param>
        /// <returns>updated project</returns>
        public IProject Update(ProjectEditModel input)
        {
            var entity = _dbc.Projects.FirstOrDefault(i => i.Id == input.Id);
            if (entity != null)
            {
                entity.Completed = input.Completed;
                entity.Started = input.Started;
                entity.Description = input.Description;
                entity.Name = input.Name;
                entity.Priority = input.Priority;
                entity.Status = input.Status;

                _dbc.SaveChanges();
            }
            return entity;
        }

        /// <summary>
        /// Deletes the project with the specified Id
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns>deleted object</returns>
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
