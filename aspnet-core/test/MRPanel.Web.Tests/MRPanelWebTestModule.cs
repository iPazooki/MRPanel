using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MRPanel.EntityFrameworkCore;
using MRPanel.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MRPanel.Web.Tests
{
    [DependsOn(
        typeof(MRPanelWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MRPanelWebTestModule : AbpModule
    {
        public MRPanelWebTestModule(MRPanelEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MRPanelWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MRPanelWebMvcModule).Assembly);
        }
    }
}