using Report.API.Models;

namespace Report.API.Dtos
{
    public class ReportInfoDto
    {
        public Guid ReportID { get; set; }
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
