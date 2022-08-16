using AutoMapper;
using PhoneBook.API.Data.Commands;
using PhoneBook.API.Requests;

namespace PhoneBook.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddContactRequest, AddContactCommand>().ReverseMap();
        }
    }
}
