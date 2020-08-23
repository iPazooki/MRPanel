using AutoMapper;
using MRPanel.Domain;

namespace MRPanel.Services
{
    public class PageMapProfile : Profile
    {
        public PageMapProfile()
        {
            CreateMap<PageDto, Page>();
        }
    }
}