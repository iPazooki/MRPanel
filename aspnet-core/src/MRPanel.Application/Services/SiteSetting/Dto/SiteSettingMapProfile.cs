using AutoMapper;
using MRPanel.Domain;

namespace MRPanel.Services
{
    public class SiteSettingMapProfile : Profile
    {
        public SiteSettingMapProfile()
        {
            CreateMap<SiteSetting, SiteSettingDto>();

            CreateMap<SiteSettingDto, SiteSetting>();
        }
    }
}