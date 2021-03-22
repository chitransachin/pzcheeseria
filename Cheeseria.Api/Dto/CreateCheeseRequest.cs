using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheeseria.Api.Dto
{
	public class CreateCheeseRequest
	{
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
