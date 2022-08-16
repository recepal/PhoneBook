namespace PhoneBook.API.Models
{
    public class Contact : BaseEntity
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string? Company { get; protected set; }

        public Contact CreateContact(string name, string surname, string? company)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Company = company;
            return this;
        }
    }
}
