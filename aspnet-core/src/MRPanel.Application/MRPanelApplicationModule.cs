using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MRPanel.Authorization;

namespace MRPanel
{
    [DependsOn(
        typeof(MRPanelCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MRPanelApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MRPanelAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MRPanelApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
