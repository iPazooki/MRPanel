using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public interface IPageAppService : IAsyncCrudAppService<PageDto, Guid>
    {
        Task<IEnumerable<PageDto>> GetAllPages();

        Task<IEnumerable<TopPageDto>> GetAllTopPages(int take = 10);
    }
}