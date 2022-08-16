namespace PhoneBook.API.Models
{
    public class ContactDetail : BaseEntity
    {
        public Guid ContactId { get; protected set; }
        public InfoType InfoType { get; protected set; }
        public string Content { get; protected set; }

        public ContactDetail CreateContactDetail(Guid contactId, InfoType infoType, string content)
        {
            Id = Guid.NewGuid();
            ContactId = contactId;
            InfoType = infoType;
            Content = content;

            return this;
        }
    }

    public enum InfoType
    {
        Number = 1,
        Email = 2,
        Location = 3
    }
}
