using MRPanel.Services;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MRPanel.Tests.Menus
{
    public class MenuAppService_Tests : MRPanelTestBase
    {
        private readonly IMenuAppService _menuAppService;

        public MenuAppService_Tests()
        {
            _menuAppService = Resolve<IMenuAppService>();
        }

        [Fact]
        public async Task CreateMenu_Test()
        {
            // Act
            var menu = new MenuDto
            {
                Title = "Home page",
                Url = "www.microsoft.com",
                Description = "Home page description",
                Icon = "active-40"
            };

            await _menuAppService.CreateAsync(menu);

            // Assert
            var menus = await _menuAppService
                .GetAllAsync(new Abp.Application.Services.Dto.PagedAndSortedResultRequestDto { MaxResultCount = 10 });

            menus.TotalCount.ShouldBeGreaterThan(0);
        }
    }
}