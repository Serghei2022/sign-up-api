using AutoMapper;
using sign_up_api.Entities;
using sign_up_api.Models;

namespace sign_up_api.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyDto>();
        CreateMap<CompanyForCreationDto, Company>();
    }
}
