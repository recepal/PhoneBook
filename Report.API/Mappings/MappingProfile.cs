using AutoMapper;
using Report.API.Dtos;
using Report.API.Models;

namespace Report.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Report, ReportDto>().ReverseMap();
            CreateMap<ReportInfo, ReportInfoDto>().ReverseMap();
        }
    }
}
