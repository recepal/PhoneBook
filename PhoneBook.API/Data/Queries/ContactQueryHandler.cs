using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.API.Context;
using PhoneBook.API.Dtos;

namespace PhoneBook.API.Data.Queries
{
    public class ContactQueryHandler : IRequestHandler<GetContactsQuery, List<ContactDto>>,
                                       IRequestHandler<GetContactWithDetailsQuery, ContactWithDetailsDto>,
                                       IRequestHandler<GetContactDetailsForReportQuery, List<ContactDetailDto>>
    {
        private readonly PostgreDbContext _context;
        private readonly IMapper _mapper;

        public ContactQueryHandler(PostgreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _context.Contacts.ToListAsync();
            var contactDtos = _mapper.Map<List<ContactDto>>(contacts);
            return contactDtos;
        }

        public async Task<ContactWithDetailsDto> Handle(GetContactWithDetailsQuery request, CancellationToken cancellationToken)
        {
            ContactWithDetailsDto contactWithDetailsDto = new();

            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == request.ContactId);
            if (contact is null) throw new Exception();

            contactWithDetailsDto.Contact = _mapper.Map<ContactDto>(contact);

            var contactDetails = await _context.ContactDetails.Where(f => f.ContactId == contact.Id).ToListAsync();
            contactWithDetailsDto.ContactDetails = _mapper.Map<List<ContactDetailDto>>(contactDetails);

            return contactWithDetailsDto;
        }

        public async Task<List<ContactDetailDto>> Handle(GetContactDetailsForReportQuery request, CancellationToken cancellationToken)
        {
            var details = await _context.ContactDetails.ToListAsync();
            return _mapper.Map<List<ContactDetailDto>>(details);
        }
    }
}
