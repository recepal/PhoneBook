namespace Report.API.Models
{
    public class ReportInfo : BaseEntity
    {
        public Guid ReportID { get; set; }
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
