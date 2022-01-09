using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;
using ProjectTracker.Domain.Views;

using System.Collections.Generic;

namespace ProjectTracker.API.Controllers
{
    /// <summary>
    /// Task's fields controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskFieldsController : AppControllerBase
    {
        private readonly IProjectTaskRepository _tasks;
        private readonly IProjectTaskFieldRepository _repository;

        /// <summary>
        /// Task's fields controller .ctor
        /// </summary>
        /// <param name="apiBehaviorOptions">Options used to configure behavior for types annotated with <see cref="Microsoft.AspNetCore.Mvc.ApiControllerAttribute"/></param>
        /// <param name="tasks">Repository for projects' tasks</param>
        /// <param name="repository">Repository for tasks's fields</param>
        public TaskFieldsController(IOptions<ApiBehaviorOptions> apiBehaviorOptions, IProjectTaskRepository tasks, IProjectTaskFieldRepository repository)
            : base(apiBehaviorOptions)
        {
            _tasks = tasks;
            _repository = repository;
        }

        /// <summary>Gets all projects' tasks' fields</summary>
        [HttpGet]
        public IEnumerable<IProjectTaskField> Get()
        {
            return _repository.GetAll().ToViews();
        }

        /// <summary>Gets task's field by specified composite key</summary>
        /// <param name="taskId">Task id</param>
        /// <param name="fieldName">Field name (case sensitive)</param>
        /// <response code="204">Field not found</response>
        [HttpGet("{taskId}/{fieldName}")]
        public IProjectTaskField GetById(int taskId, string fieldName)
        {
            return _repository.GetById(taskId, fieldName).ToView();
        }

        /// <summary>Creates task's field with specified value</summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Invalid parameters</response>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectTaskFieldModel input)
        {
            var task = _tasks.GetById(input.TaskId);
            if (task == null)
            {
                ModelState.AddModelError(nameof(input.TaskId),
                    "Specified task does not exist.");
            }
            if (_repository.GetById(input.TaskId, input.Name) != null)
            {
                ModelState.AddModelError(nameof(input.Name),
                    "Specified field is already exists.");
            }
            if (!ModelState.IsValid)
            {
                return ValidationError();
            }
            var newField = _repository.Create(input);
            return CreatedAtAction(nameof(GetById), new { taskId = newField.TaskId, fieldName = newField.Name }, newField.ToView());
        }

        /// <summary>Updates task's field</summary>
        /// <response code="400">Invalid parameters</response>
        /// <response code="404">Field not found</response>
        /// <response code="204">Successfully updated</response>
        [HttpPut]
        public IActionResult Put([FromBody] ProjectTaskFieldModel input)
        {
            if (_tasks.GetById(input.TaskId) == null)
            {
                ModelState.AddModelError(nameof(input.TaskId),
                    "Specified task does not exist.");
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

        /// <summary>Deletes task's field by specified composite key</summary>
        /// <response code="404">Field not found</response>
        /// <response code="204">Successfully deleted</response>
        [HttpDelete("{taskId}/{fieldName}")]
        public IActionResult Delete(int taskId, string fieldName)
        {
            var result = _repository.Delete(taskId, fieldName);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
