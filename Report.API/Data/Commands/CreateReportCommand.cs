using MediatR;

namespace Report.API.Data.Commands
{
    public class CreateReportCommand : IRequest<Guid>
    {
    }
}
