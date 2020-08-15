using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MRPanel.Configuration.Dto;

namespace MRPanel.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MRPanelAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
