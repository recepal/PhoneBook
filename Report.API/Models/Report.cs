namespace Report.API.Models
{
    public class Report : BaseEntity
    {
        public DateTime RequestDate { get; protected set; }
        public ReportStatus ReportStatus { get; protected set; }

        public Report Create()
        {
            Id = Guid.NewGuid();
            RequestDate = DateTime.Now.ToUniversalTime();
            ReportStatus = ReportStatus.Preparing;

            return this;
        }

        public Report SetCompleted()
        {
            ReportStatus = ReportStatus.Completed;

            return this;
        }
    }

    public enum ReportStatus
    {
        Preparing,
        Completed
    }
}
