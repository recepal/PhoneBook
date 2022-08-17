using MediatR;
using Report.API.Dtos;

namespace Report.API.Data.Queries
{
    public class GetReportByIdQuery : IRequest<ReportDto>
    {
        public Guid ReportId { get; set; }

        public GetReportByIdQuery(Guid reportId)
        {
            ReportId = reportId;
        }
    }
}
