using Cheeseria.Api.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheeseria.Api.Validators
{
	public class CreateCheeseRequestValidator : AbstractValidator<CreateCheeseRequest>
	{
		public CreateCheeseRequestValidator()
		{
			RuleFor(model => model.CommonName).NotEmpty().WithMessage("Please specify the name of the Cheese");
			RuleFor(model => model.Colour).NotEmpty().WithMessage("Cheese must have a colour");
			RuleFor(model => model.Country).NotEmpty().WithMessage("Specify the origin country");
			RuleFor(model => model.QualityScore).InclusiveBetween(1, 10).WithMessage("Specify a score between 1 and 10");
		}
	}
}
