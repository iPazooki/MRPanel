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
            CreateMap<Page, TopPageDto>()
                .ForMember(x => x.MenuTitle, s => s.MapFrom(m => m.Menu.Title));

            CreateMap<Page, SitePageDto>();
        }
    }
}