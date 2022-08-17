namespace Report.API.Services
{
    public interface IReportService
    {
        Task<Guid> CreateReport();
        Task CreateReportInfo(Guid id);
    }
}
