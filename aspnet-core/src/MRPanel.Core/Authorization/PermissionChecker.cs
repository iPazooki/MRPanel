using Abp.Authorization;
using MRPanel.Authorization.Roles;
using MRPanel.Authorization.Users;

namespace MRPanel.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
