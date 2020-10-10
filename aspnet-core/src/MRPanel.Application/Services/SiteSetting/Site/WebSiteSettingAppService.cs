using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using MRPanel.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public class WebSiteSettingAppService : IWebSiteSettingAppService
    {
        private readonly IRepository<SiteSetting> _siteSettingRepository;
        private readonly IObjectMapper _objectMapper;

        public WebSiteSettingAppService(IRepository<SiteSetting> siteSettingRepository, IObjectMapper objectMapper)
        {
            _siteSettingRepository = siteSettingRepository;
            _objectMapper = objectMapper;
        }

        public async Task<SiteSettingDto> Get()
        {
            var siteSetting = (await _siteSettingRepository.GetAllListAsync()).Single();
            return _objectMapper.Map<SiteSettingDto>(siteSetting);
        }
    }
}