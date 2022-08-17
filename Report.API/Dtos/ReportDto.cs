using Report.API.Models;

namespace Report.API.Dtos
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
    }
}
