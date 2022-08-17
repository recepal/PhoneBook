using PhoneBook.API.Models;

namespace PhoneBook.API.Dtos
{
    public class ContactDetailDto
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public InfoType InfoType { get; set; }
        public string Content { get; set; }
    }
}
