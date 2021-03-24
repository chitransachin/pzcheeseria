using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cheeseria.Api.Dto;
using Cheeseria.Api.Handlers;
using Cheeseria.Api.Handlers.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cheeseria.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheeseController : ControllerBase
    {
        private readonly ILogger<CheeseController> _logger;

        public CheeseController(ILogger<CheeseController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetCheeseResponse), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCheese([FromServices] IActionHandlerAsync<GetCheeseRequest, IEnumerable<GetCheeseResponse>> actionHandler, CancellationToken cancellationToken)
        {
            var result = await actionHandler.ProcessAsync(new GetCheeseRequest {}, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{cheeseId}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetCheeseResponse), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCheese(int cheeseId, [FromServices] IActionHandlerAsync<GetCheeseRequest, IEnumerable<GetCheeseResponse>> actionHandler, CancellationToken cancellationToken)
        {
            var result = await actionHandler.ProcessAsync(new GetCheeseRequest { Id = cheeseId }, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CreateCheeseResponse), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCheese([FromBody] CreateCheeseRequest request, [FromServices] IActionHandlerAsync<CreateCheeseRequest, CreateCheeseResponse> actionHandler, CancellationToken cancellationToken)
		{
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var result = await actionHandler.ProcessAsync(request, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{cheeseId}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DeleteCheeseResponse), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCheese(int cheeseId, [FromServices] IActionHandlerAsync<DeleteCheeseRequest, DeleteCheeseResponse> actionHandler, CancellationToken cancellationToken)
		{
            var result = await actionHandler.ProcessAsync(new DeleteCheeseRequest { Id = cheeseId }, cancellationToken);
            return Ok(result);
        }
    }
}
