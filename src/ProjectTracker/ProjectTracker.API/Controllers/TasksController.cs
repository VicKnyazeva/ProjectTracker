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
    public class TasksController : AppControllerBase
    {
        private readonly IProjectRepository _projects;
        private readonly IProjectTaskRepository _repository;

        public TasksController(IOptions<ApiBehaviorOptions> apiBehaviorOptions, IProjectRepository projects, IProjectTaskRepository repository)
            : base(apiBehaviorOptions)
        {
            _projects = projects;
            _repository = repository;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<IProjectTask> Get()
        {
            return _repository.GetAll().ToViews();
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public IProjectTask GetById(int id)
        {
            return _repository.GetById(id).ToView();
        }

        // POST api/<TasksController>
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

        // PUT api/<TasksController>/5
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

        // DELETE api/<TasksController>/5
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
