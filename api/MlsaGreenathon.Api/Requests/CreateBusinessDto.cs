using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace MlsaGreenathon.Api.Requests
{
    public class CreateBusinessDto
    {
        public string Name { get; set; }

        public string AddressLine { get; set; }

        public string Town { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public class Validator : AbstractValidator<CreateBusinessDto>
        {
            public Validator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .MaximumLength(30);

                RuleFor(x => x.AddressLine)
                    .NotEmpty()
                    .MaximumLength(30);

                RuleFor(x => x.Town)
                    .NotEmpty()
                    .MaximumLength(30);

                RuleFor(x => x.ZipCode)
                    .NotEmpty()
                    .MaximumLength(30);

                RuleFor(x => x.Country)
                    .NotEmpty()
                    .MaximumLength(30);
            }
        }
    }
}
