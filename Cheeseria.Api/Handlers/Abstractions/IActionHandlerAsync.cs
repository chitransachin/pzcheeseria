using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cheeseria.Api.Handlers.Abstractions
{
	public interface IActionHandlerAsync<TRequest, TResponse>
	{
		Task<TResponse> ProcessWithValidationAsync(TRequest request, CancellationToken cancellationToken);

		Task<TResponse> ProcessAsync(TRequest request, CancellationToken cancellationToken);
	}
}
