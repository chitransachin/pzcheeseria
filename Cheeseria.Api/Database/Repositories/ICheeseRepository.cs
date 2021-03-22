using Cheeseria.Api.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cheeseria.Api.Database.Repositories
{
	public interface ICheeseRepository
	{
		Task<IEnumerable<CheeseEntity>> GetCheeseCollection(CancellationToken cancellationToken);
		Task<CheeseEntity> GetCheese(int cheeseId, CancellationToken cancellationToken);
		Task<CheeseEntity> CreateCheese(CheeseEntity newCheese, CancellationToken cancellationToken);
		Task<bool> DeleteCheese(int cheeseId, CancellationToken cancellationToken);
		Task<CheeseEntity> UpdateCheese(CheeseEntity updateCheese, CancellationToken cancellationToken);
	}
}
