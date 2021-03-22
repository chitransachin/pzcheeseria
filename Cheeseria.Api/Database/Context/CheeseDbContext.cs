using Cheeseria.Api.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheeseria.Api.Database.Context
{
	public class CheeseDbContext : DbContext
	{
		public CheeseDbContext(DbContextOptions<CheeseDbContext> options) : base(options)
		{
		}

		public DbSet<CheeseEntity> Cheeses { get; set; }
	}
}
