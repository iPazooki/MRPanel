using Abp.Application.Services;
using System;

namespace MRPanel.Services
{
    public interface IPageAppService : IAsyncCrudAppService<PageDto, Guid>
    {
    }
}