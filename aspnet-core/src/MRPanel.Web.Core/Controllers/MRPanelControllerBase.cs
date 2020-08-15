using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MRPanel.Controllers
{
    public abstract class MRPanelControllerBase: AbpController
    {
        protected MRPanelControllerBase()
        {
            LocalizationSourceName = MRPanelConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
