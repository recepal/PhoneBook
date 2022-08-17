using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Report.API.Services;
using System.Text;

namespace Report.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IHttpClientFactory _httpClientFactory;


        //https://localhost:7089/api
        //amqp://guest:guest@localhost:5672

        public ReportController(IReportService reportService, IHttpClientFactory httpClientFactory)
        {
            _reportService = reportService;
            _httpClientFactory = httpClientFactory;

        }

        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            //var client = _httpClientFactory.CreateClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7089/api/Contact/GetContacts");
            //var response = await client.SendAsync(request);

            //var responseStream = await response.Content.ReadAsStringAsync();
            var reportId = await _reportService.CreateReport();
            

            ConnectionFactory connectionFactory = new()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();
            channel.ExchangeDeclare("reportExchange", "direct");

            channel.QueueDeclare("reportQueue", false, false, false);
            channel.QueueBind("reportQueue", "reportExchange", "reportQueue");
            channel.BasicPublish("reportExchange", "reportQueue", null, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(reportId)));

            return Accepted();
        }
    }
}
