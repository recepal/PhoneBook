using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Report.API.Data.Commands;
using Report.API.Data.Queries;
using Report.API.Dtos;
using static Report.API.Constants.Settings;

namespace Report.API.Services
{
    public class ReportService : IReportService
    {
        private readonly IMediator _mediatrHandler;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;


        public ReportService(IMediator mediatrHandler, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mediatrHandler = mediatrHandler;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Guid> CreateReport()
        {
            CreateReportCommand command =  new CreateReportCommand();
            var result = await _mediatrHandler.Send(command);
            return result;
        }

        public async Task CreateReportInfo(Guid id)
        {
            var report = await _mediatrHandler.Send(new GetReportByIdQuery(id));
            string url = $"{ServiceUrlConfig.ContactBaseUrl}{ServiceUrlConfig.GetContactDetailsForReportService.GetContactDetailsForReport}";
            //"https://localhost:7089/api/Contact/GetContactDetailsForReport"
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);

            var stream = await response.Content.ReadAsStringAsync();
            var contactDetails = JsonConvert.DeserializeObject<IEnumerable<ContactDetailDto>>(stream);

            var infos = contactDetails.Where(f => f.InfoType == InfoType.Location)
                .GroupBy(g => new {g.ContactId, g.InfoType, g.Content}).Select(s => new ReportInfoDto
            {
                ReportID = report.Id,
                ContactCount = contactDetails.Where(f => f.InfoType == InfoType.Location && f.Content == s.Key.Content).Count(),//s.Select(f=> f.ContactId).Count(),
                PhoneNumberCount = contactDetails.Where(f => f.InfoType == InfoType.Number).Count(),
                Location = s.Key.Content
            }) ;

            await _mediatrHandler.Send(new CreateReportInfosCommand(infos.ToList()));

            await _mediatrHandler.Send(new ReportSetCompletedCommand(report.Id)); 

        }

        public async Task<List<ReportDto>> GetAllReports()
        {
            var result = await _mediatrHandler.Send(new GetAllReportsQuery());
            return result;
        }

        public async Task<List<ReportInfoDto>> GetReportInfosByReportId(Guid reportId)
        {
            var result = await _mediatrHandler.Send(new GetReportInfosByReportIdQuery(reportId));
            return result;
        }
    }
}
