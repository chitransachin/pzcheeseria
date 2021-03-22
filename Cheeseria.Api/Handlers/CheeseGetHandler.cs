﻿using Cheeseria.Api.Handlers.Abstractions;
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
	public class CheeseGetHandler : IActionHandlerAsync<GetCheeseRequest, IEnumerable<GetCheeseResponse>>
	{
		private readonly ICheeseRepository _cheeseRepository;
		private readonly IMapper _mapper;

		public CheeseGetHandler(ICheeseRepository cheeseRepository, IMapper mapper)
		{
			_cheeseRepository = cheeseRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<GetCheeseResponse>> ProcessAsync(GetCheeseRequest request, CancellationToken cancellationToken)
		{
			CheeseEntity reqEntity = null;

			if (request.Id > 0)
			{
				reqEntity = await _cheeseRepository.GetCheese(request.Id, cancellationToken);
				return _mapper.Map<IEnumerable<GetCheeseResponse>>(reqEntity);
			}
			else
			{
				var allCheeseEntity = await _cheeseRepository.GetCheeseCollection(cancellationToken);
				return _mapper.Map<IEnumerable<GetCheeseResponse>>(allCheeseEntity);
			}
		}

		Task<IEnumerable<GetCheeseResponse>> IActionHandlerAsync<GetCheeseRequest, IEnumerable<GetCheeseResponse>>.ProcessWithValidationAsync(GetCheeseRequest request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
