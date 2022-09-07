using AutoMapper;
using MediatR;
using Moq;
using PhoneBook.API.Mappings;
using PhoneBook.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhoneBook.Test
{
    public class ContactServiceTest
    {
        private readonly IMapper _mapper;
        private readonly ContactService _personService;

        public ContactServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            var mediator = new Mock<IMediator>();

            _personService = new ContactService(mediator.Object, _mapper);

        }

        [Fact]
        public async Task GetAll_Contacts_Records()
        {
            var returnedValue = await _personService.GetContacts();

            Assert.NotNull(returnedValue);
        }
    }
}
