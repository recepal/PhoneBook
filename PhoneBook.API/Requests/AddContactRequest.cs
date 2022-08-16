namespace PhoneBook.API.Requests
{
    public class AddContactRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Company { get; set; }
    }
}
