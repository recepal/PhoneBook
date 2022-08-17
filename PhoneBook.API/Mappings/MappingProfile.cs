using AutoMapper;
using PhoneBook.API.Data.Commands;
using PhoneBook.API.Dtos;
using PhoneBook.API.Models;
using PhoneBook.API.Requests;

namespace PhoneBook.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddContactRequest, AddContactCommand>().ReverseMap();
            CreateMap<AddContactDetailRequest, AddContactDetailCommand>().ReverseMap();

            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<ContactDetail, ContactDetailDto>().ReverseMap();

        }
    }
}
