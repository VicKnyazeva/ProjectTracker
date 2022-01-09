using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;
using ProjectTracker.Domain.Views;

using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTracker.API.Controllers
{
    /// <summary>Projects Controller</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : AppControllerBase
    {
        private readonly IProjectRepository _repository;

        public ProjectsController(IOptions<ApiBehaviorOptions> apiBehaviorOptions, IProjectRepository repository)
            : base(apiBehaviorOptions)
        {
            this._repository = repository;
        }

        /// <summary>Gets all projects</summary>
        // GET: api/<ProjectsController>
        [HttpGet]
        public IEnumerable<IProject> Get([FromQuery] ProjectFilterAndSort filter = null)
        {
            return _repository.GetAll(filter).ToViews();
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public IProject GetById(int id)
        {
            return _repository.GetById(id).ToView();
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectCreateModel input)
        {
            if (_repository.GetAll(null).Any(p => p.Name == input.Name))
            {
                ModelState.AddModelError(nameof(input.Name),
                    "This project name is already in use.");
            }
            if (!ModelState.IsValid)
            {
                return ValidationError();
            }
            var newProject = _repository.Create(input);
            return CreatedAtAction(nameof(GetById), new { id = newProject.Id }, newProject.ToView());
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectEditModel input)
        {
            long? excludeId = null;
            if (id == input.Id)
                excludeId = id;
            else
            {
                ModelState.AddModelError(nameof(input.Id), "Invalid value");
            }
            if (_repository.GetAll(null).Any(p => p.Id != id && p.Name == input.Name))
            {
                ModelState.AddModelError(nameof(input.Name),
                    "This project name is already in use.");
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

        // DELETE api/<ProjectsController>/5
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
