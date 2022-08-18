using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.API.Services;
using System.Text;
using System.Text.Json;
using static Report.API.Constants.Settings;

namespace Report.API.Middleware
{
    public static class RabbitMqListener
    {
        //https://stackoverflow.com/questions/43609345/setup-rabbitmq-consumer-in-asp-net-core-application
        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            string connectionStr = ServiceUrlConfig.RabbitMqConnectionString;

            ConnectionFactory connectionFactory = new()
            {
                Uri = new Uri(connectionStr)
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();
            channel.ExchangeDeclare("reportExchange", "direct");
            channel.QueueDeclare("reportQueue", false, false, false);
            channel.QueueBind("reportQueue", "reportExchange", "reportQueue");
            var consumerEvent = new EventingBasicConsumer(channel);

            consumerEvent.Received += (ch, ea) =>
            {
                var reportService = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IReportService>();
                var reportId = JsonSerializer.Deserialize<Guid>(Encoding.UTF8.GetString(ea.Body.ToArray()));
               
                reportService.CreateReportInfo(reportId);
            };

            channel.BasicConsume("reportQueue", true, consumerEvent);

            return app;
        }
    }
}
