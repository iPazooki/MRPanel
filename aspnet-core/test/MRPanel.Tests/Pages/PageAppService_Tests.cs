using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using MRPanel.Services;
using Abp.Timing;
using MRPanel.Domain;

namespace MRPanel.Tests.Users
{
    public class PageAppService_Tests : MRPanelTestBase
    {
        private readonly IPageAppService _pageAppService;

        public PageAppService_Tests()
        {
            _pageAppService = Resolve<IPageAppService>();
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
        public async Task CreatePage_Test()
        {
            // Act
            var page = new PageDto
            {
                Title = "Lorem Ipsum is simply dummy text of the printing and typesetting",
                Summery = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                CreationTime = Clock.Now,
                PageType = Domain.PageType.Page,
                IsDeleted = false,
                IsHomePage = false
            };

            await CreatePage(page);

            await UsingDbContextAsync(async context =>
            {
                var page = await context.Pages.FirstOrDefaultAsync(x => x.IsHomePage == false);

                page.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task Update_Page_Test()
        {
            // Act
            var pageDto = new PageDto
            {
                Title = "Lorem Ipsum is simply dummy text of the printing and typesetting",
                CreationTime = Clock.Now,
                PageType = Domain.PageType.Page,
                IsDeleted = false,
                IsHomePage = true
            };

            var resultPage = await CreatePage(pageDto);

            resultPage.PageType.ShouldBe<PageType>(PageType.Page);

            resultPage.PageType = PageType.News;

            var updatedPage = await UpdatePage(resultPage);

            // Assert
            updatedPage.PageType.ShouldBe(PageType.News);
        }

        [Fact]
        public async Task Safe_Delete_Page_Test()
        {
            // Act
            var pageDto = new PageDto
            {
                Title = "Lorem Ipsum is simply dummy text of the printing and typesetting",
                CreationTime = Clock.Now,
                PageType = Domain.PageType.Page,
                IsDeleted = false,
                IsHomePage = true
            };

            var resultPage = await CreatePage(pageDto);

            await _pageAppService.DeleteAsync(resultPage);

            // Assert

            await UsingDbContextAsync(async context =>
            {
                var deletedPage = await context.Pages.AnyAsync(x => x.IsDeleted);

                deletedPage.ShouldBeTrue();

                var anyPage = await context.Pages.AnyAsync(x => x.IsDeleted == false);

                anyPage.ShouldBeFalse();
            });
        }

        public async Task<PageDto> CreatePage(PageDto page)
        {
            return await _pageAppService.CreateAsync(page);
        }

        private async Task<PageDto> UpdatePage(PageDto page)
        {
            return await _pageAppService.UpdateAsync(page);
        }
    }
}