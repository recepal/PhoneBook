namespace PhoneBook.API.Dtos
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Company { get; set; }
    }
}
