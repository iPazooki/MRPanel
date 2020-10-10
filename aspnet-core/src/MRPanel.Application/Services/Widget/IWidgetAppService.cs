using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public interface IWidgetAppService : IApplicationService
    {
        Task<IEnumerable<WidgetDto>> GetAll();

        Task<IEnumerable<WidgetDto>> GetByPageId(Guid pageId);

        Task<Guid> Save(WidgetDto widget);

        Task<WidgetDto> Get(Guid id);

        Task SaveList(Guid pageId, List<WidgetDto> widgetDtos);

        Task Delete(Guid widgetId);
    }
}