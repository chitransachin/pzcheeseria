using Cheeseria.Api.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheeseria.Api.Validators
{
	public class GetCheeseRequestValidator : AbstractValidator<GetCheeseRequest>
	{
		public GetCheeseRequestValidator()
		{
			RuleFor(model => model.CommonName).NotEmpty().WithMessage("Please specify the name of the Cheese");
		}
	}
}
