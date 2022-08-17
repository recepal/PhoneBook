using MediatR;
using Report.API.Dtos;

namespace Report.API.Data.Commands
{
    public class CreateReportInfosCommand : IRequest<bool>
    {
        public List<ReportInfoDto> ReportInfos { get; set; }
        public CreateReportInfosCommand(List<ReportInfoDto> reportInfos)
        {
            ReportInfos = reportInfos;
        }
    }
}
