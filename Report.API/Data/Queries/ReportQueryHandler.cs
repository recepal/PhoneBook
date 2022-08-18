using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Report.API.Context;
using Report.API.Dtos;

namespace Report.API.Data.Queries
{
    public class ReportQueryHandler : IRequestHandler<GetReportByIdQuery, ReportDto>,
                                      IRequestHandler<GetAllReportsQuery, List<ReportDto>>,
                                      IRequestHandler<GetReportInfosByReportIdQuery, List<ReportInfoDto>>
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

        public async Task<List<ReportDto>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = await _context.Reports.ToListAsync();

            return _mapper.Map<List<ReportDto>>(reports);
        }

        public async Task<List<ReportInfoDto>> Handle(GetReportInfosByReportIdQuery request, CancellationToken cancellationToken)
        {
            var reportInfos = await _context.ReportInfos.Where(f => f.ReportID == request.ReportId).ToListAsync();

            return _mapper.Map<List<ReportInfoDto>>(reportInfos);
        }
    }
}
