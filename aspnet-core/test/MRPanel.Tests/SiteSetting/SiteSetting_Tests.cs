using MRPanel.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MRPanel.Tests.SiteSetting
{
    public class SiteSetting_Tests : MRPanelTestBase
    {
        private readonly ISiteSettingAppService _siteSettingAppService;
        private readonly IWebSiteSettingAppService _webSiteSettingAppService;

        public SiteSetting_Tests()
        {
            _siteSettingAppService = Resolve<ISiteSettingAppService>();
            _webSiteSettingAppService = Resolve<IWebSiteSettingAppService>();
        }

        [Fact]
        public async Task GetSiteSetting_Test()
        {
            // Act
            var siteSetting = await _siteSettingAppService.Get();

            // Assert
            siteSetting.SiteName.ShouldBe("MRPanel");
        }

        [Fact]
        public async Task SaveSiteSetting_Test()
        {
            // Act
            var siteSettingDto = new SiteSettingDto { SiteName = "CMS" };

            var result = await _siteSettingAppService.Save(siteSettingDto);

            // Assert
            result.SiteName.ShouldBe("CMS");
        }

        [Fact]
        public async Task GetWebSiteSetting_Test()
        {
            // Act

            await SaveSiteSetting_Test();

            var siteSetting = await _webSiteSettingAppService.Get();

            // Assert
            siteSetting.SiteName.ShouldBe("CMS");
        }
    }
}