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

                RuleFor(x => x.Industry)
                    .NotEmpty()
                    .MaximumLength(20);

                When(x => x.Logo != null, () =>
                {
                    RuleFor(x => x.Logo.FileName)
                        .Must(x => x.EndsWith(".png")); // end with png

                    RuleFor(x => x.Logo.ContentType)
                        .Equal("image/png").WithMessage("The logo's MIME type must be 'image/png'");

                    RuleFor(x => x.Logo.Length)
                        .LessThanOrEqualTo(2000000).WithMessage("Logo must be less than 2 MB");
                });

                RuleFor(x => x.MissionStatement)
                    .NotEmpty()
                    .MaximumLength(1000);

                // Address
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
                    .Must(BeAValidIsoCountryCode).WithMessage("'{PropertyValue}' is not a valid ISO 3166-1 country code");
            }

            private static bool BeAValidIsoCountryCode(string isoCode) => 
                Defaults.IsoCountryCodes.ToList().Exists(z => z.Code == isoCode);
        }
    }
}
