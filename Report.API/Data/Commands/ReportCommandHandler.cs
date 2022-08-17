using MediatR;
using Microsoft.EntityFrameworkCore;
using Report.API.Context;
using Report.API.Models;

namespace Report.API.Data.Commands
{
    public class ReportCommandHandler : IRequestHandler<CreateReportCommand, Guid>,
                                        IRequestHandler<ReportSetCompletedCommand, bool>,
                                        IRequestHandler<CreateReportInfosCommand, bool>
    {
        private readonly PostgreDbContext _context;

        public ReportCommandHandler(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Models.Report().Create();
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();

            return report.Id;

        }

        public async Task<bool> Handle(ReportSetCompletedCommand request, CancellationToken cancellationToken)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(f => f.Id == request.ReportId);
            if (report is null) throw new Exception();

            report.SetCompleted();
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Handle(CreateReportInfosCommand request, CancellationToken cancellationToken)
        {
            foreach (var info in request.ReportInfos)
            {
                var reportInfo = new ReportInfo().Create(info.ReportID, info.Location, info.ContactCount, info.PhoneNumberCount);
                await _context.ReportInfos.AddAsync(reportInfo);

            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
