using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using MlsaGreenathon.Api.Properties;

namespace MlsaGreenathon.Api.Requests
{
    public class QueryBusinessDto
    {
        public 
    }

    public class CreateBusinessDto
    {
        public string Name { get; set; }

        public string AddressLine { get; set; }

        public string Town { get; set; }

        public string ZipCode { get; set; }

        public string CountryIsoCode { get; set; }

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

                RuleFor(x => x.CountryIsoCode)
                    .NotEmpty()
                    .Must(BeAValidIsoCountryCode);
            }

            private static bool BeAValidIsoCountryCode(string isoCode) => 
                Defaults.IsoCountryCodes.ToList().Exists(z => z.Code == isoCode);
        }
    }
}
