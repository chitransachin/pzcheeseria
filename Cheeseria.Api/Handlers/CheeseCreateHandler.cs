using Cheeseria.Api.Handlers.Abstractions;
using Cheeseria.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cheeseria.Api.Database.Repositories;
using AutoMapper;
using Cheeseria.Api.Database.Models;

namespace Cheeseria.Api.Handlers
{
	public class CheeseCreateHandler : IActionHandlerAsync<CreateCheeseRequest, CreateCheeseResponse>
	{
		private readonly ICheeseRepository _cheeseRepository;
		private readonly IMapper _mapper;

		public CheeseCreateHandler(ICheeseRepository cheeseRepository, IMapper mapper)
		{
			_cheeseRepository = cheeseRepository;
			_mapper = mapper;
		}

		public async Task<CreateCheeseResponse> ProcessAsync(CreateCheeseRequest request, CancellationToken cancellationToken)
		{
			//Map the dto to entity type before calling the repository
			var cheeseEntity = _mapper.Map<CheeseEntity>(request);

			var savedEntity = await _cheeseRepository.CreateCheese(cheeseEntity, cancellationToken);

			return _mapper.Map<CreateCheeseResponse>(savedEntity);
		}

		public Task<CreateCheeseResponse> ProcessWithValidationAsync(CreateCheeseRequest request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
