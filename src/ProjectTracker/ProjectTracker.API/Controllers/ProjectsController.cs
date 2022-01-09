using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using ProjectTracker.Domain;
using ProjectTracker.Domain.Models;
using ProjectTracker.Domain.Views;

using System.Collections.Generic;
using System.Linq;

namespace ProjectTracker.API.Controllers
{
    /// <summary>
    /// Projects controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : AppControllerBase
    {
        private readonly IProjectRepository _repository;

        /// <summary>
        /// Projects Controller .ctor
        /// </summary>
        /// <param name="apiBehaviorOptions">Options used to configure behavior for types annotated with <see cref="Microsoft.AspNetCore.Mvc.ApiControllerAttribute"/></param>
        /// <param name="repository">Projects repository</param>
        public ProjectsController(IOptions<ApiBehaviorOptions> apiBehaviorOptions, IProjectRepository repository)
            : base(apiBehaviorOptions)
        {
            this._repository = repository;
        }

        /// <summary>Gets projects with filters and sorting</summary>
        /// <response code="400">Invalid parameters</response>
        [HttpGet]
        public IEnumerable<IProject> Get([FromQuery] ProjectFilterAndSort filter = null)
        {
            return _repository.GetAll(filter).ToViews();
        }

        /// <summary>Gets project by specified Id</summary>
        /// <response code="204">Project not found</response>
        [HttpGet("{id}")]
        public IProject GetById(int id)
        {
            return _repository.GetById(id).ToView();
        }

        /// <summary>Creates new project</summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Invalid parameters</response>
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

        /// <summary>Updates project with specified Id</summary>
        /// <response code="400">Invalid parameters</response>
        /// <response code="404">Project not found</response>
        /// <response code="204">Successfully updated</response>
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

        /// <summary>Deletes project with specified Id</summary>
        /// <response code="404">Project not found</response>
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
