namespace Report.API.Models
{
    public class Report : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
    }

    public enum ReportStatus
    {
        Preparing,
        Completed
    }
}
