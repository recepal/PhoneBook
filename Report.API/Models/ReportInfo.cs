namespace Report.API.Models
{
    public class ReportInfo : BaseEntity
    {
        public Guid ReportID { get; set; }
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneNumberCount { get; set; }

        public ReportInfo Create(Guid reportId, string location, int contactCount, int phoneNumberCount)
        {
            Id = Guid.NewGuid();
            ReportID = reportId;
            Location = location;
            ContactCount = contactCount;
            PhoneNumberCount = phoneNumberCount;

            return this;
        }
    }
}
