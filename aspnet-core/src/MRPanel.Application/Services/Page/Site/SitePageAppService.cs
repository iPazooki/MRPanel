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
        private readonly IRepository<Menu, Guid> _menuRepository;
        private readonly IObjectMapper _objectMapper;
        private readonly IRepository<Widget, Guid> _widgetRepository;

        public SitePageAppService(IRepository<Page, Guid> pageRepository, IRepository<Menu, Guid> menuRepository, IObjectMapper objectMapper, IRepository<Widget, Guid> widgetRepository)
        {
            _pageRepository = pageRepository;
            _menuRepository = menuRepository;
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

            await _pageRepository.EnsureCollectionLoadedAsync(page, x => x.Widgets);

            var sitePageDto = _objectMapper.Map<SitePageDto>(page);

            return sitePageDto;
        }

        public async Task<SitePageDto> GetPageByUrl(string url)
        {
            var menu = await _menuRepository.FirstOrDefaultAsync(x => x.Url == url);

            if (menu == null)
            {
                return null;
            }

            //await _menuRepository.EnsurePropertyLoadedAsync(menu, x => x.Page);
            menu.Page = await _pageRepository.GetAsync(menu.PageId.Value);

            await _pageRepository.EnsureCollectionLoadedAsync(menu.Page, x => x.Widgets);

            return _objectMapper.Map<SitePageDto>(menu.Page);
        }
    }
}