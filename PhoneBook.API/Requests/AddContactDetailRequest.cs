using PhoneBook.API.Models;

namespace PhoneBook.API.Requests
{
    public class AddContactDetailRequest
    {
        public Guid ContactId { get; set; }
        public InfoType InfoType { get; set; }
        public string Content { get; set; }
    }
}
