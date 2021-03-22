using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheeseria.Api.Database.Models
{
	public class CheeseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string CommonName { get; set; }
		public string Country { get; set; }
		public string AnimalSource { get; set; }
		public string Family { get; set; }
		public string Colour { get; set; }
		public string Aroma { get; set; }
		public bool IsPremium { get; set; }
		public int QualityScore { get; set; }
	}
}
