using AutoMapper;
using Cheeseria.Api.Database.Models;
using Cheeseria.Api.Database.Repositories;
using Cheeseria.Api.Dto;
using Cheeseria.Api.Handlers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cheeseria.Api.Handlers
{
	public class DeleteCheeseHandler : IActionHandlerAsync<DeleteCheeseRequest, DeleteCheeseResponse>
	{ 
		private readonly ICheeseRepository _cheeseRepository;
		private readonly IMapper _mapper;

		public DeleteCheeseHandler(ICheeseRepository cheeseRepository, IMapper mapper)
		{
			_cheeseRepository = cheeseRepository;
			_mapper = mapper;
		}

		public async Task<DeleteCheeseResponse> ProcessAsync(DeleteCheeseRequest request, CancellationToken cancellationToken)
		{
			var wasDeleted = await _cheeseRepository.DeleteCheese(request.Id, cancellationToken);

			return new DeleteCheeseResponse { IsSuccess = wasDeleted };
		}
	}
}
