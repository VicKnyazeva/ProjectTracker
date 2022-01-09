using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ProjectTracker.API.Controllers
{
    /// <summary>An API controlles base class</summary>
    [ApiController]
    public abstract class AppControllerBase : ControllerBase
    {
        private IOptions<ApiBehaviorOptions> _apiBehaviorOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppControllerBase"/> class
        /// </summary>
        /// <param name="apiBehaviorOptions">Options used to configure behavior for types
        /// annotated with <see cref="Microsoft.AspNetCore.Mvc.ApiControllerAttribute"/></param>
        protected AppControllerBase(IOptions<ApiBehaviorOptions> apiBehaviorOptions)
        {
            _apiBehaviorOptions = apiBehaviorOptions;
        }

        /// <summary>Creates validation error action result</summary>
        /// <returns>validation error action result</returns>
        protected ActionResult ValidationError()
        {
            return (_apiBehaviorOptions.Value.InvalidModelStateResponseFactory(this.ControllerContext) as ActionResult)!;
        }
    }
}
