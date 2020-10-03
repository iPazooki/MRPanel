using AutoMapper;
using MRPanel.Domain;

namespace MRPanel.Services
{
    public class PageMapProfile : Profile
    {
        public PageMapProfile()
        {
            CreateMap<PageDto, Page>();
            CreateMap<Page, PageDto>();

            CreateMap<Page, SitePageDto>()
                .ForMember(x => x.Widgets, s => s.Ignore());
        }
    }
}