using AutoMapper;
using Cheeseria.Api.Database.Models;
using Cheeseria.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheeseria.Api.Mappers
{
	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			CreateMap<CreateCheeseRequest, CheeseEntity>();
			CreateMap<CheeseEntity, CreateCheeseResponse>();
			CreateMap<CheeseEntity, GetCheeseResponse>();
		}
	}
}
