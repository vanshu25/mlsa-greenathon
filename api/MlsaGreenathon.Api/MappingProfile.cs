using AutoMapper;
using MlsaGreenathon.Api.Requests;
using MlsaGreenathon.Models;

namespace MlsaGreenathon.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBusinessDto, Business>(MemberList.Source);
        }
    }
}