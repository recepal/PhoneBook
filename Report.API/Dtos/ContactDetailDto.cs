namespace Report.API.Dtos
{
    public class ContactDetailDto
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public InfoType InfoType { get; set; }
        public string Content { get; set; }
    }

    public enum InfoType
    {
        Number = 1,
        Email = 2,
        Location = 3
    }
}
