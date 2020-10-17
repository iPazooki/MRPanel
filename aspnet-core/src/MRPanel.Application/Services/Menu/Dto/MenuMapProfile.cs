using AutoMapper;
using MRPanel.Domain;

namespace MRPanel.Services
{
    public class MenuMapProfile : Profile
    {
        public MenuMapProfile()
        {
            CreateMap<MenuDto, Menu>()
                .ForMember(x => x.Menus, s => s.Ignore());

            CreateMap<Menu, MenuDto>()
                .ForMember(x => x.PageName, s =>
                {
                    s.PreCondition(x => x.PageId.HasValue);
                    s.MapFrom(d => d.Page.Title);
                });

            CreateMap<Menu, SiteMenuDto>();
        }
    }
}