using Cheeseria.Api.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheeseria.Api.Database.Context
{
	public class CheeseSQLiteDBContext : DbContext
	{
		public DbSet<CheeseEntity> Cheeses { get; set; }

		public CheeseSQLiteDBContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CheeseEntity>()
				.HasIndex(c => new { c.CommonName, c.Country })
				.IsUnique(true);
		}
	}
}
