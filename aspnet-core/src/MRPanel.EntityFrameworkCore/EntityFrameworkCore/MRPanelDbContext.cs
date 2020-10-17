using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MRPanel.Authorization.Roles;
using MRPanel.Authorization.Users;
using MRPanel.MultiTenancy;
using MRPanel.Domain;
using System.Reflection;

namespace MRPanel.EntityFrameworkCore
{
    public class MRPanelDbContext : AbpZeroDbContext<Tenant, Role, User, MRPanelDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Page> Pages { get; set; }

        public DbSet<Widget> Widgets { get; set; }

        public DbSet<SiteSetting> SiteSettings { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public MRPanelDbContext(DbContextOptions<MRPanelDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}