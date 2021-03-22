using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheeseria.Api.Dto
{
	public class CreateCheeseResponse
	{
		public Int64 CheeseId { get; set; }
		public bool WasCreated { get; set; }
	}
}
