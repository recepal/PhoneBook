using MediatR;
using Report.API.Dtos;

namespace Report.API.Data.Queries
{
    public class GetReportInfosByReportIdQuery : IRequest<List<ReportInfoDto>>
    {
        public Guid ReportId { get; set; }

        public GetReportInfosByReportIdQuery(Guid reportId)
        {
            ReportId = reportId;
        }
    }
}
