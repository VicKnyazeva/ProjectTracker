using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ProjectTracker.API.Controllers
{
    [ApiController]
    public abstract class AppControllerBase : ControllerBase
    {
        private IOptions<ApiBehaviorOptions> _apiBehaviorOptions;

        protected AppControllerBase(IOptions<ApiBehaviorOptions> apiBehaviorOptions)
        {
            _apiBehaviorOptions = apiBehaviorOptions;
        }

        protected ActionResult ValidationError()
        {
            return (_apiBehaviorOptions.Value.InvalidModelStateResponseFactory(this.ControllerContext) as ActionResult)!;
        }
    }
}
