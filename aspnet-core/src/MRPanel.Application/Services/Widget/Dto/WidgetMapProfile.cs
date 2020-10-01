using AutoMapper;
using MRPanel.Domain;

namespace MRPanel.Services
{
    public class WidgetMapProfile : Profile
    {
        public WidgetMapProfile()
        {
            CreateMap<Widget, WidgetDto>();

            CreateMap<WidgetSaveDto, Widget>()
                .ForMember(x => x.Page, s => s.Ignore())
                .ForMember(x => x.Parent, s => s.Ignore())
                .ForMember(x => x.Widgets, s => s.Ignore());
        }
    }
}