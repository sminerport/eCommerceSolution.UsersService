using AutoMapper;

using eCommerce.Core.Domain.IdentityEntities;
using eCommerce.Core.DTO;

namespace eCommerce.Core.Mappers;

public class ApplicationUserToUserDTOMappingProfile : Profile
{
    public ApplicationUserToUserDTOMappingProfile()
    {
        CreateMap<ApplicationUser, UserDTO>()
            .ForMember(
                dest => dest.UserID,
                opt => opt.MapFrom(src => src.UserID))
            .ForMember(
                dest => dest.PersonName,
                opt => opt.MapFrom(src => src.PersonName))
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(
                dest => dest.Gender,
                opt => opt.MapFrom(src => src.Gender));
    }
}