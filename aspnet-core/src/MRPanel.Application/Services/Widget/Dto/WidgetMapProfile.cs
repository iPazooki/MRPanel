using AutoMapper;
using MRPanel.Domain;

namespace MRPanel.Services
{
    public class WidgetMapProfile : Profile
    {
        public WidgetMapProfile()
        {
            CreateMap<Widget, WidgetDto>();

            CreateMap<WidgetDto, Widget>()
                .ForMember(x => x.Widgets, s => s.Ignore())
                .ForMember(x => x.Id, s => s.PreCondition(w => w.Id.HasValue));
        }
    }
}