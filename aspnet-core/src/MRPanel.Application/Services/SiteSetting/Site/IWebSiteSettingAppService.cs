using Abp.Application.Services;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public interface IWebSiteSettingAppService : IApplicationService
    {
        Task<SiteSettingDto> Get();
    }
}