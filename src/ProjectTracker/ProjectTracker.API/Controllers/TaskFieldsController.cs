using Microsoft.AspNetCore.Mvc;

using ProjectTracker.Domain.Views;
using ProjectTracker.Domain;

using System.Collections.Generic;
using System.Linq;
using ProjectTracker.Domain.Models;
using Microsoft.Extensions.Options;

namespace ProjectTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskFieldsController : AppControllerBase
    {
        private readonly IProjectTaskRepository _tasks;
        private readonly IProjectTaskFieldRepository _repository;

        public TaskFieldsController(IOptions<ApiBehaviorOptions> apiBehaviorOptions, IProjectTaskRepository tasks, IProjectTaskFieldRepository repository)
            : base(apiBehaviorOptions)
        {
            _tasks = tasks;
            _repository = repository;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<IProjectTaskField> Get()
        {
            return _repository.GetAll().ToViews();
        }

        // GET api/<TasksController>/5
        [HttpGet("{taskId}/{fieldName}")]
        public IProjectTaskField GetById(int taskId, string fieldName)
        {
            return _repository.GetById(taskId, fieldName).ToView();
        }

        // POST api/<TasksController>
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

        // PUT api/<TasksController>/5
        [HttpPut("{taskId}/{fieldName}")]
        public IActionResult Put(int taskId, string fieldName, [FromBody] ProjectTaskFieldModel input)
        {
            if (taskId != input.TaskId)
            {
                ModelState.AddModelError(nameof(input.TaskId), "Invalid value");
            }
            if (fieldName != input.Name)
            {
                ModelState.AddModelError(nameof(input.Name), "Invalid value");
            }
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

        // DELETE api/<TasksController>/5
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
