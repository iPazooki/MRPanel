using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MRPanel.Authorization
{
    public class MRPanelAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Pages, L("Pages"));
            context.CreatePermission(PermissionNames.Pages_Menu, L("Menu"));
            context.CreatePermission(PermissionNames.Pages_SiteSetting, L("SiteSetting"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MRPanelConsts.LocalizationSourceName);
        }
    }
}