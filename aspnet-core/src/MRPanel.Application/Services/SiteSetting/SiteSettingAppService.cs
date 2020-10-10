using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using MRPanel.Authorization;
using MRPanel.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    [AbpAuthorize(PermissionNames.Pages_SiteSetting)]
    public class SiteSettingAppService : ApplicationService, ISiteSettingAppService
    {
        private readonly IRepository<SiteSetting> _siteSettingRepository;
        private readonly IObjectMapper _objectMapper;

        public SiteSettingAppService(IRepository<SiteSetting> siteSettingRepository, IObjectMapper objectMapper)
        {
            _siteSettingRepository = siteSettingRepository;
            _objectMapper = objectMapper;
        }

        public async Task<SiteSettingDto> Get()
        {
            var siteSetting = (await _siteSettingRepository.GetAllListAsync()).SingleOrDefault();

            if (siteSetting == null)
            {
                return await Save(new SiteSettingDto { SiteName = "MRPanel" });
            }
            else return _objectMapper.Map<SiteSettingDto>(siteSetting);
        }

        public async Task<SiteSettingDto> Save(SiteSettingDto siteSettingDto)
        {
            var siteSetting = _objectMapper.Map<SiteSetting>(siteSettingDto);

            var result = await _siteSettingRepository.InsertOrUpdateAsync(siteSetting);

            return _objectMapper.Map<SiteSettingDto>(result);
        }
    }
}