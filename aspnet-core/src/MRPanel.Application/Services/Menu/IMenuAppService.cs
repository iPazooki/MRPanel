using Abp.Application.Services;
using System;

namespace MRPanel.Services
{
    public interface IMenuAppService : IAsyncCrudAppService<MenuDto, Guid>
    {
    }
}