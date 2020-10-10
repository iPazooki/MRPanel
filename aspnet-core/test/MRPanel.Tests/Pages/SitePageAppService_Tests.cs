using System.Threading.Tasks;
using Shouldly;
using Xunit;
using MRPanel.Services;
using Abp.Timing;
using System.Linq;

namespace MRPanel.Tests.Users
{
    public class SitePageAppService_Tests : PageAppService_Tests
    {
        private readonly ISitePageAppService _sitePageAppService;

        public SitePageAppService_Tests()
        {
            _sitePageAppService = Resolve<ISitePageAppService>();
        }

        [Fact]
        public async Task GetSitePages_Null_Test()
        {
            // Act
            var output = await _sitePageAppService.GetAllByPageType(Domain.PageType.Page);

            // Assert
            output.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetSitePages_Test()
        {
            // Act
            var page = new PageDto
            {
                Title = "Lorem Ipsum is simply dummy text of the printing and typesetting",
                Summery = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
                CreationTime = Clock.Now,
                PageType = Domain.PageType.News,
                IsDeleted = false,
                IsHomePage = false
            };

            await CreatePage(page);

            var result = await _sitePageAppService.GetAllByPageType(Domain.PageType.News);

            // Assert
            result.Count().Equals(1);
        }

        [Fact]
        public async Task Create_Home_Page_Test()
        {
            // Act
            var page = new PageDto
            {
                Title = "Lorem Ipsum is simply dummy text of the printing and typesetting",
                CreationTime = Clock.Now,
                PageType = Domain.PageType.Page,
                IsDeleted = false,
                IsHomePage = true
            };

            await CreatePage(page);

            var result = await _sitePageAppService.GetHomePage();

            // Assert
            result.ShouldNotBeNull();
        }
    }
}