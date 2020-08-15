using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MRPanel.Configuration;

namespace MRPanel.Web.Host.Startup
{
    [DependsOn(
       typeof(MRPanelWebCoreModule))]
    public class MRPanelWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MRPanelWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MRPanelWebHostModule).GetAssembly());
        }
    }
}
