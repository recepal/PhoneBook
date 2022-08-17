using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.API.Context;
using PhoneBook.API.Models;

namespace PhoneBook.API.Data.Commands
{
    public class ContactCommandHandler : IRequestHandler<AddContactCommand, bool>,
                                         IRequestHandler<DeleteContactCommand, bool>,
                                         IRequestHandler<AddContactDetailCommand, bool>,
                                         IRequestHandler<DeleteContactDetailCommand, bool>
    {
        private readonly PostgreDbContext _context;

        public ContactCommandHandler(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact().CreateContact(request.Name, request.Surname, request.Company);
            await _context.Contacts.AddAsync(contact);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(f => f.Id == request.Id);
            if (contact is null) throw new Exception();
            _context.Contacts.Remove(contact);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Handle(AddContactDetailCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(f => f.Id == request.ContactId);
            if (contact is null) throw new Exception();

            var contactDetail = new ContactDetail().CreateContactDetail(contact.Id, request.InfoType, request.Content);
            await _context.ContactDetails.AddAsync(contactDetail);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Handle(DeleteContactDetailCommand request, CancellationToken cancellationToken)
        {
            var contactDetail = await _context.ContactDetails.FirstOrDefaultAsync(f => f.Id == request.Id);
            if (contactDetail is null) throw new Exception();
            _context.ContactDetails.Remove(contactDetail);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
