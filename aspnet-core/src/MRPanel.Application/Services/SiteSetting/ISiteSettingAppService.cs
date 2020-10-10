using Abp.Application.Services;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public interface ISiteSettingAppService : IApplicationService
    {
        Task<SiteSettingDto> Get();

        Task<SiteSettingDto> Save(SiteSettingDto siteSettingDto);
    }
}