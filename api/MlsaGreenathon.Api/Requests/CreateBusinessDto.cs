using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using MlsaGreenathon.Api.Properties;

namespace MlsaGreenathon.Api.Requests
{
    public class CreateBusinessDto
    {
        public string Name { get; set; }

        public string Industry { get; set; }

        [IgnoreMap]
        public IFormFile Logo { get; set; }

        public string MissionStatement { get; set; }

        // Address
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
