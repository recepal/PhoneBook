using MediatR;
using Report.API.Dtos;

namespace Report.API.Data.Queries
{
    public class GetAllReportsQuery : IRequest<List<ReportDto>>
    {
       
    }
}
