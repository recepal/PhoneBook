using MediatR;
using PhoneBook.API.Models;

namespace PhoneBook.API.Data.Commands
{
    public class AddContactDetailCommand : IRequest<bool>
    {
        public Guid ContactId { get;  set; }
        public InfoType InfoType { get;  set; }
        public string Content { get;  set; }
    }
}
