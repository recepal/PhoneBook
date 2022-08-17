using Microsoft.EntityFrameworkCore;
using Report.API.Models;

namespace Report.API.Context
{
    public class PostgreDbContext : DbContext
    {
        public DbSet<Models.Report> Reports { get; set; }
        public DbSet<ReportInfo> ReportInfos { get; set; }

        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
        {

        }
    }
}
