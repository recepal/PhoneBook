using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Report.API.Context;
using Report.API.Dtos;

namespace Report.API.Data.Queries
{
    public class ReportQueryHandler : IRequestHandler<GetReportByIdQuery, ReportDto>
    {
        private readonly PostgreDbContext _context;
        private readonly IMapper _mapper;


        public ReportQueryHandler(PostgreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReportDto> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(f => f.Id == request.ReportId);

            return _mapper.Map<ReportDto>(report);

        }
    }
}
