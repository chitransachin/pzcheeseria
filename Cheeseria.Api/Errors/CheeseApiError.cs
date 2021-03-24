using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cheeseria.Api.Errors
{
	public class CheeseApiError
	{
		public int StatusCode { get; private set; }
		public string StatusDescription { get; private set; }
		public string Message { get; private set; }

		public CheeseApiError(int statusCode, string statusDescription, string message = null)
		{
			StatusCode = statusCode;
			StatusDescription = statusDescription;
			Message = message;
		}
	}

	//Adding it here for lack of time - we could handle other types of errors (Unauthorized, Forbidden, UnAuthenticated, Internal Server Error (5XX), 4XX etc)

	public class NotFoundError : CheeseApiError
	{
		public NotFoundError() : base(404, HttpStatusCode.NotFound.ToString())
		{
		}
	}

	public class InternalServerError : CheeseApiError
	{
		public InternalServerError() : base(500, HttpStatusCode.InternalServerError.ToString())
		{
		}
	}
}
