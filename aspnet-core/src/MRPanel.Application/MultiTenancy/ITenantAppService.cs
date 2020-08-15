using Abp.Application.Services;
using MRPanel.MultiTenancy.Dto;

namespace MRPanel.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

