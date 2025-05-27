using AutoMapper;

using eCommerce.Core.Domain.IdentityEntities;
using eCommerce.Core.DTO;

namespace eCommerce.Core.Mappers;
public class RegisterRequestToApplicationUserMappingProfile : Profile
{
    public RegisterRequestToApplicationUserMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(
            d => d.PersonName,
            opt => opt.MapFrom(src => src.PersonName))
            .ForMember(
            d => d.Email,
            opt => opt.MapFrom(src => src.Email))
            .ForMember(
                d => d.Password,
                opt => opt.MapFrom(src => src.Password))
            .ForMember(
                d => d.Gender,
                opt => opt.MapFrom(src => src.Gender.ToString()));
    }
}