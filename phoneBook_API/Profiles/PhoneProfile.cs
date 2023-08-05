using AutoMapper;
using phoneBook_API.Data.DTO;
using phoneBook_API.Models;

namespace phoneBook_API.Profiles
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile() {
            CreateMap<PhoneDTO, Phone>();
            CreateMap<UpdatePhoneDTO, Phone>();
        }
    }
}
