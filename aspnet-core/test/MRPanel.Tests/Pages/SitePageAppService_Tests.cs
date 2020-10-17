using System.Threading.Tasks;
using Shouldly;
using Xunit;
using MRPanel.Services;
using Abp.Timing;
using System.Linq;
using MRPanel.Domain;

namespace MRPanel.Tests.Users
{
    public class SitePageAppService_Tests : PageAppService_Tests
    {
        private readonly ISitePageAppService _sitePageAppService;
        private readonly IMenuAppService _menuAppService;
        private readonly IWidgetAppService _widgetAppService;

        public SitePageAppService_Tests()
        {
            _sitePageAppService = Resolve<ISitePageAppService>();
            _menuAppService = Resolve<IMenuAppService>();
            _widgetAppService = Resolve<IWidgetAppService>();
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
                PageType = PageType.Page,
                IsDeleted = false,
                IsHomePage = true
            };

            page = await CreatePage(page);

            var widget = new WidgetDto
            {
                Content = "Welcome!",
                PageId = page.Id,
                Order = 0,
                Position = Domain.Enum.Position.Left,
                SizeType = Domain.Enum.SizeType._100,
                WidgetType = Domain.Enum.WidgetType.Paragraph
            };

            await _widgetAppService.Save(widget);

            var result = await _sitePageAppService.GetHomePage();

            // Assert
            result.ShouldNotBeNull();
            result.Widgets.Count.ShouldBe(1);
            result.Widgets.First().Content.ShouldBe("Welcome!");
        }

        [Fact]
        public async Task Get_Page_By_URL_Test()
        {
            // Act
            var page = new PageDto
            {
                Title = "About us",
                CreationTime = Clock.Now,
                PageType = PageType.Page
            };

            page = await CreatePage(page);

            var widget = new WidgetDto
            {
                Content = "Welcome!",
                PageId = page.Id,
                Order = 0,
                Position = Domain.Enum.Position.Left,
                SizeType = Domain.Enum.SizeType._100,
                WidgetType = Domain.Enum.WidgetType.Paragraph
            };

            await _widgetAppService.Save(widget);

            var menu = new MenuDto
            {
                PageId = page.Id,
                Title = "About us",
                IsExternal = false,
                Url = "about-us"
            };

            await _menuAppService.CreateAsync(menu);

            var result = await _sitePageAppService.GetPageByUrl("about-us");

            // Assert
            result.Title.ShouldBe("About us");
            result.Widgets.ShouldNotBeNull();
            result.Widgets.First().Content.ShouldBe("Welcome!");
        }
    }
}