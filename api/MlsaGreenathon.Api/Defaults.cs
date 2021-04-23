using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MlsaGreenathon.Api.Data;
using MlsaGreenathon.Api.Properties;
using Newtonsoft.Json;

namespace MlsaGreenathon.Api
{
    public static class Defaults
    {
        public const string DefaultStorageConnection = "DefaultStorageAccount";

        public static Mapper Mapper = new Mapper(
            new MapperConfiguration(x => 
                x.AddMaps(typeof(Defaults))));

        public static IReadOnlyCollection<IsoCountryCode> IsoCountryCodes =
            JsonConvert.DeserializeObject<List<IsoCountryCode>>(Resources.Countries_Iso_3166_1);
    }
}
