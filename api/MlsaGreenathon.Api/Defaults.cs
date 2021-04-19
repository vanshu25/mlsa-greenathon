using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace MlsaGreenathon.Api
{
    public static class Defaults
    {
        public const string DefaultStorageConnection = "DefaultStorageAccount";

        public static Mapper Mapper = new Mapper(
            new MapperConfiguration(x => 
                x.AddMaps(typeof(Defaults))));
    }
}
