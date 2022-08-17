using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Report.API.Data.Commands;
using Report.API.Data.Queries;
using Report.API.Dtos;

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

            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7089/api/Contact/GetContactDetailsForReport");
            var response = await client.SendAsync(request);

            var stream = await response.Content.ReadAsStringAsync();
            var contactDetails = JsonConvert.DeserializeObject<IEnumerable<ContactDetailDto>>(stream);

            var infos = contactDetails.GroupBy(f => f.InfoType == InfoType.Location).Select(s => new ReportInfoDto
            {
                ReportID = report.Id,
                ContactCount = s.Select(f => f.ContactId).Count(),
                PhoneNumberCount = s.Where(f => f.InfoType == InfoType.Number).Count(),
                Location = s.FirstOrDefault(f => f.InfoType == InfoType.Location).Content
            }) ;

            await _mediatrHandler.Send(new CreateReportInfosCommand(infos.ToList())); ;

            await _mediatrHandler.Send(new ReportSetCompletedCommand(report.Id)); 

        }
    }
}
