using Cheeseria.Api.Database.Models;
using Cheeseria.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheeseria.Api.Tests.Helpers
{
	public class GetCheeseHandlerHelper
	{
		public static CheeseEntity GetCheeseEntity(int id, int qualityScore)
		{
			return new CheeseEntity
			{
				AnimalSource = "Cow",
				Aroma = "Sweet",
				Id = id,
				PricePerKilo = 199,
				QualityScore = qualityScore
			};
		}

		public static IEnumerable<CheeseEntity> GetCheeseCollection()
		{
			var allCheeseCollection = new List<CheeseEntity>()
			{
				new CheeseEntity
				{
					AnimalSource = "Cow",
					Aroma = "Sweet",
					Id = 1,
					PricePerKilo = 15,
					QualityScore = 1
				},
				new CheeseEntity
				{
					AnimalSource = "Goat",
					Aroma = "Cream",
					Id = 2,
					PricePerKilo = 25,
					QualityScore = 2
				},
				new CheeseEntity
				{
					AnimalSource = "Sheep",
					Aroma = "Milky",
					Id = 3,
					PricePerKilo = 35,
					QualityScore = 3
				},
				new CheeseEntity
				{
					AnimalSource = "Buffalo",
					Aroma = "Sour",
					Id = 4,
					PricePerKilo = 45,
					QualityScore = 4
				},
				new CheeseEntity
				{
					AnimalSource = "Donkey",
					Aroma = "Pungent",
					Id = 5,
					PricePerKilo = 55,
					QualityScore = 5
				},
			};

			return allCheeseCollection;
		}

		public static IEnumerable<GetCheeseResponse> GetCheeseResponseCollection()
		{
			var cheeseResponseCollection = new List<GetCheeseResponse>()
			{
				new GetCheeseResponse
				{
					AnimalSource = "Cow",
					Aroma = "Sweet",
					Id = 1,
					PricePerKilo = 15,
					QualityScore = 1
				},
				new GetCheeseResponse
				{
					AnimalSource = "Goat",
					Aroma = "Cream",
					Id = 2,
					PricePerKilo = 25,
					QualityScore = 2
				},
				new GetCheeseResponse
				{
					AnimalSource = "Sheep",
					Aroma = "Milky",
					Id = 3,
					PricePerKilo = 35,
					QualityScore = 3
				},
				new GetCheeseResponse
				{
					AnimalSource = "Buffalo",
					Aroma = "Sour",
					Id = 4,
					PricePerKilo = 45,
					QualityScore = 4
				},
				new GetCheeseResponse
				{
					AnimalSource = "Donkey",
					Aroma = "Pungent",
					Id = 5,
					PricePerKilo = 55,
					QualityScore = 5
				}
			};

			return cheeseResponseCollection;
		}

		public static GetCheeseRequest CreateGetRequest(string name, int id)
		{
			return new GetCheeseRequest { CommonName = name, Id = id };
		}
	}
}
