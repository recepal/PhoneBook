namespace Report.API.Constants
{
    public class Settings
    {
        public static class ServiceUrlConfig
        {
            public static string ContactBaseUrl => "https://localhost:7089/api/";
            public static string RabbitMqConnectionString => "amqp://guest:guest@localhost:5672";
            public static class GetContactDetailsForReportService
            {
                public static string GetContactDetailsForReport => $"Contact/GetContactDetailsForReport";
            }
        }
    }
}
