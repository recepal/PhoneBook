using AutoMapper;
using MediatR;
using PhoneBook.API.Data.Commands;
using PhoneBook.API.Requests;

namespace PhoneBook.API.Services
{
    public class ContactService : IContactService
    {
        private readonly IMediator _mediatrHandler;
        private readonly IMapper _mapper;

        public ContactService(IMediator mediatrHandler, IMapper mapper)
        {
            _mediatrHandler = mediatrHandler;
            _mapper = mapper;
        }

        public async Task<bool> AddContact(AddContactRequest request)
        {
            AddContactCommand command = _mapper.Map<AddContactCommand>(request);
            var result = await _mediatrHandler.Send(command);
            return result;
        }
    }
}
