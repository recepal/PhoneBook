using MediatR;
using PhoneBook.API.Context;
using PhoneBook.API.Models;

namespace PhoneBook.API.Data.Commands
{
    public class ContactCommandHandler : IRequestHandler<AddContactCommand, bool>
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
    }
}
