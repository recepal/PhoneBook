using AutoMapper;
using MediatR;
using PhoneBook.API.Data.Commands;
using PhoneBook.API.Data.Queries;
using PhoneBook.API.Dtos;
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

        public async Task<bool> DeleteContact(Guid id)
        {
            var command = new DeleteContactCommand(id);
            var result = await _mediatrHandler.Send(command);
            return result;
        }

        public async Task<bool> AddContactDetail(AddContactDetailRequest request)
        {
            AddContactDetailCommand command = _mapper.Map<AddContactDetailCommand>(request);
            var result = await _mediatrHandler.Send(command);
            return result;
        }

        public async Task<bool> DeleteContactDetail(Guid id)
        {
            var command = new DeleteContactDetailCommand(id);
            var result = await _mediatrHandler.Send(command);
            return result;
        }

        public async Task<List<ContactDto>> GetContacts()
        {
            var query = new GetContactsQuery();
            var result = await _mediatrHandler.Send(query);
            return result;
        }

        public async Task<ContactWithDetailsDto> GetContactWithDetails(Guid contactId)
        {
            var query = new GetContactWithDetailsQuery(contactId);
            var result = await _mediatrHandler.Send(query);
            return result;
        }
    }
}
