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
			CreateMap<CreateCheeseRequest, CheeseEntity>()
				.ForMember(r => r.CreatedAt, r => r.MapFrom(x => DateTime.UtcNow));

			CreateMap<CheeseEntity, CreateCheeseResponse>()
				.ForMember(cr => cr.CheeseId, e => e.MapFrom(x => x.Id))
				.ForMember(cr => cr.WasCreated, e => e.MapFrom(x => x.Id > 0));
			
			CreateMap<CheeseEntity, GetCheeseResponse>();
				
		}
	}
}
