using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MRPanel.Authorization.Roles;
using MRPanel.Authorization.Users;
using MRPanel.MultiTenancy;

namespace MRPanel.EntityFrameworkCore
{
    public class MRPanelDbContext : AbpZeroDbContext<Tenant, Role, User, MRPanelDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MRPanelDbContext(DbContextOptions<MRPanelDbContext> options)
            : base(options)
        {
        }
    }
}
