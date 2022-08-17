using MediatR;

namespace Report.API.Data.Commands
{
    public class ReportSetCompletedCommand : IRequest<bool>
    {
        public Guid ReportId { get; set; }

        public ReportSetCompletedCommand(Guid reportId)
        {
            ReportId = reportId;
        }
    }
}
