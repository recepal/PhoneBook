namespace PhoneBook.API.Dtos
{
    public class ContactWithDetailsDto
    {
        public ContactDto Contact { get; set; }
        public List<ContactDetailDto> ContactDetails { get; set; }
    }
}
