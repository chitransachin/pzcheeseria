using Cheeseria.Api.Database.Context;
using Cheeseria.Api.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cheeseria.Api.Database.Repositories
{
	public class CheeseRepository : ICheeseRepository
	{
		private readonly CheeseDbContext _dbContext;
		public CheeseRepository(CheeseDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public async Task<CheeseEntity> CreateCheese(CheeseEntity newCheese, CancellationToken cancellationToken)
		{
			var result = await _dbContext.Cheeses.AddAsync(newCheese);
			await _dbContext.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<bool> DeleteCheese(int cheeseId, CancellationToken cancellationToken)
		{
			var result = await _dbContext.Cheeses.FirstOrDefaultAsync(ch => ch.Id == cheeseId);

			if(result != null)
			{
				_dbContext.Cheeses.Remove(result);
				await _dbContext.SaveChangesAsync();
				return true;
			}

			return false;
		}

		public async Task<CheeseEntity> GetCheese(int cheeseId, CancellationToken cancellationToken)
		{
			return await _dbContext.Cheeses.FirstOrDefaultAsync(ch => ch.Id == cheeseId);
		}

		public async Task<IEnumerable<CheeseEntity>> GetCheeseCollection(CancellationToken cancellationToken)
		{
			return await _dbContext.Cheeses.ToListAsync();
		}

		public async Task<CheeseEntity> UpdateCheese(CheeseEntity updateCheese, CancellationToken cancellationToken)
		{
			var result = await _dbContext.Cheeses.FirstOrDefaultAsync(ch => ch.Id	== updateCheese.Id);

			if (result != null)
			{
				result.CommonName = updateCheese.CommonName;
				result.Country= updateCheese.Country;
				result.UpdatedAt = DateTime.UtcNow;

				await _dbContext.SaveChangesAsync();

				return result;
			}

			return null;
		}
	}
}
