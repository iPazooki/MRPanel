using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using MRPanel.Services;
using Abp.Timing;

namespace MRPanel.Tests.Users
{
    public class PageAppService_Tests : MRPanelTestBase
    {
        private readonly IPageAppService _pageAppService;
        private readonly ISitePageAppService _sitePageAppService;

        public PageAppService_Tests()
        {
            _pageAppService = Resolve<IPageAppService>();
            _sitePageAppService = Resolve<ISitePageAppService>();
        }

        [Fact]
        public async Task GetPages_Test()
        {
            // Act

            await CreatePage_Test();

            var output = await _pageAppService.GetAllAsync(
                new PagedAndSortedResultRequestDto
                {
                    MaxResultCount = 20,
                    SkipCount = 0
                });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task GetSitePages_Test()
        {
            // Act
            var output = await _sitePageAppService.GetAllByPageType(Domain.PageType.Page);

            // Assert
            output.ShouldBeEmpty();
        }

        [Fact]
        public async Task CreatePage_Test()
        {
            // Act
            await _pageAppService.CreateAsync(
                new PageDto
                {
                    Title = "Lorem Ipsum is simply dummy text of the printing and typesetting",
                    Summery = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    CreationTime = Clock.Now,
                    PageType = Domain.PageType.Page,
                    IsDeleted = false,
                    IsHomePage = false
                });

            await UsingDbContextAsync(async context =>
            {
                var page = await context.Pages.FirstOrDefaultAsync();

                page.ShouldNotBeNull();
            });
        }
    }
}