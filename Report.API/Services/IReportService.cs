using Report.API.Dtos;

namespace Report.API.Services
{
    public interface IReportService
    {
        Task<Guid> CreateReport();
        Task CreateReportInfo(Guid id);
        Task<List<ReportDto>> GetAllReports();
        Task<List<ReportInfoDto>> GetReportInfosByReportId(Guid reportId);

    }
}
