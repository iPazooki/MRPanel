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

        Task<Guid> Save(WidgetSaveDto widget);

        Task<WidgetDto> Get(Guid id);
    }
}