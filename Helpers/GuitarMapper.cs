using AutoMapper;
using Realm_Api_Poc;

class GuitarMapper : Profile
{
    public GuitarMapper()
    {
        CreateMap<GuitarDTO,Guitar>().ReverseMap();
    }
}