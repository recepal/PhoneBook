using MediatR;

namespace PhoneBook.API.Data.Commands
{
    public class AddContactCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Company { get; set; }
    }
}
