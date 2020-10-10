using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using MRPanel.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public class SitePageAppService : ISitePageAppService
    {
        private readonly IRepository<Page, Guid> _pageRepository;
        private readonly IObjectMapper _objectMapper;
        private readonly IRepository<Widget, Guid> _widgetRepository;

        public SitePageAppService(IRepository<Page, Guid> pageRepository, IObjectMapper objectMapper, IRepository<Widget, Guid> widgetRepository)
        {
            _pageRepository = pageRepository;
            _objectMapper = objectMapper;
            _widgetRepository = widgetRepository;
        }

        public async Task<IEnumerable<SitePageDto>> GetAllByPageType(PageType pageType)
        {
            var items = await _pageRepository.GetAllListAsync(x => x.PageType == pageType && x.IsHomePage == false);

            return _objectMapper.Map<List<SitePageDto>>(items);
        }

        public async Task<SitePageDto> GetHomePage()
        {
            var page = await _pageRepository.FirstOrDefaultAsync(x => x.IsHomePage);

            var sitePageDto = _objectMapper.Map<SitePageDto>(page);

            var widgets = await _widgetRepository.GetAllListAsync(x => x.PageId == page.Id);

            sitePageDto.Widgets = _objectMapper.Map<List<WidgetDto>>(widgets);

            return sitePageDto;
        }
    }
}