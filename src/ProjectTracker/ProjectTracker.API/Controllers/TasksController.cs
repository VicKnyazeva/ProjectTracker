using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;
using ProjectTracker.Domain.Views;

using System.Collections.Generic;

namespace ProjectTracker.API.Controllers
{
    /// <summary>
    /// Project's tasks controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : AppControllerBase
    {
        private readonly IProjectRepository _projects;
        private readonly IProjectTaskRepository _repository;

        /// <summary>
        /// Project's task controller .ctor
        /// </summary>
        /// <param name="apiBehaviorOptions">Options used to configure behavior for types annotated with <see cref="Microsoft.AspNetCore.Mvc.ApiControllerAttribute"/></param>
        /// <param name="projects">Projects repository</param>
        /// <param name="repository">Tasks repository</param>
        public TasksController(IOptions<ApiBehaviorOptions> apiBehaviorOptions, IProjectRepository projects, IProjectTaskRepository repository)
            : base(apiBehaviorOptions)
        {
            _projects = projects;
            _repository = repository;
        }

        /// <summary>Gets all projects' tasks</summary>
        [HttpGet]
        public IEnumerable<IProjectTask> Get()
        {
            return _repository.GetAll().ToViews();
        }

        /// <summary>Gets tasks by specified Id</summary>
        /// <response code="204">Task not found</response>
        [HttpGet("{id}")]
        public IProjectTask GetById(int id)
        {
            return _repository.GetById(id).ToView();
        }

        /// <summary>Creates new task</summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Invalid parameters</response>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectTaskCreateModel input)
        {
            if (_projects.GetById(input.ProjectId) == null)
            {
                ModelState.AddModelError(nameof(input.ProjectId),
                    "Specified project does not exist.");
            }
            if (!ModelState.IsValid)
            {
                return ValidationError();
            }
            var newTask = _repository.Create(input);
            return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask.ToView());
        }

        /// <summary>Updates task with specified Id</summary>
        /// <response code="400">Invalid parameters</response>
        /// <response code="404">Task not found</response>
        /// <response code="204">Successfully updated</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectTaskEditModel input)
        {
            long? excludeId = null;
            if (id == input.Id)
                excludeId = id;
            else
            {
                ModelState.AddModelError(nameof(input.Id), "Invalid value");
            }
            if (_projects.GetById(input.ProjectId) == null)
            {
                ModelState.AddModelError(nameof(input.ProjectId),
                    "Specified project does not exist.");
            }
            if (!ModelState.IsValid)
            {
                return ValidationError();
            }
            var result = _repository.Update(input);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>Deletes task with specified Id</summary>
        /// <response code="404">Task not found</response>
        /// <response code="204">Successfully deleted</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
