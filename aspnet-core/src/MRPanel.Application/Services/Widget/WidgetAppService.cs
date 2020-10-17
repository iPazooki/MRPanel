using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using MRPanel.Authorization;
using MRPanel.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    [AbpAuthorize(PermissionNames.Pages_Pages)]
    public class WidgetAppService : ApplicationService, IWidgetAppService
    {
        private readonly IRepository<Widget, Guid> _widgetRepository;
        private readonly IRepository<Page, Guid> _pageRepository;
        private readonly IObjectMapper _objectMapper;

        public WidgetAppService(IRepository<Widget, Guid> widgetRepository, IRepository<Page, Guid> pageRepository, IObjectMapper objectMapper)
        {
            _widgetRepository = widgetRepository;
            _pageRepository = pageRepository;
            _objectMapper = objectMapper;
        }

        public async Task Delete(Guid widgetId)
        {
            await _widgetRepository.DeleteAsync(x => x.ParentId == widgetId);

            await _widgetRepository.DeleteAsync(widgetId);
        }

        public async Task<WidgetDto> Get(Guid id)
        {
            var widget = await _widgetRepository.GetAsync(id);

            return _objectMapper.Map<WidgetDto>(widget);
        }

        public async Task<IEnumerable<WidgetDto>> GetAll()
        {
            var items = await _widgetRepository.GetAllListAsync();

            return _objectMapper.Map<List<WidgetDto>>(items);
        }

        public async Task<IEnumerable<WidgetDto>> GetByPageId(Guid pageId)
        {
            var items = await _widgetRepository.GetAllListAsync(x => x.PageId == pageId);

            return _objectMapper.Map<List<WidgetDto>>(items);
        }

        public async Task<Guid> Save(WidgetDto widget)
        {
            var widgetObj = _objectMapper.Map<Widget>(widget);

            return await _widgetRepository.InsertOrUpdateAndGetIdAsync(widgetObj);
        }

        public async Task SaveList(Guid pageId, List<WidgetDto> widgetDtos)
        {
            foreach (var widgetDto in widgetDtos)
            {
                widgetDto.PageId = pageId;

                await Save(widgetDto);
            }
        }
    }
}