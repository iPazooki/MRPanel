using System.Threading.Tasks;
using Shouldly;
using Xunit;
using MRPanel.Services;
using System.Linq;
using MRPanel.Domain.Enum;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System;

namespace MRPanel.Tests.Users
{
    public class WidgetAppService_Tests : PageAppService_Tests
    {
        private readonly IPageAppService _pageAppService;
        private readonly IWidgetAppService _widgetAppService;

        public WidgetAppService_Tests()
        {
            _pageAppService = Resolve<IPageAppService>();
            _widgetAppService = Resolve<IWidgetAppService>();
        }

        [Fact]
        public async Task GetWidgets_Test()
        {
            // Act
            await CreateWidget_Test();

            var output = _widgetAppService.GetAll();

            // Assert
            output.ShouldNotBeNull();
        }

        [Fact]
        public async Task CreateWidget_Test()
        {
            // Act

            await CreatePage_Test();

            var pages = await _pageAppService.GetAllAsync(new PagedAndSortedResultRequestDto() { MaxResultCount = 10 });

            var page = pages.Items.FirstOrDefault();

            var widgetDto = new WidgetDto
            {
                Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                WidgetType = WidgetType.Paragraph,
                PageId = page.Id,
                ParentId = null,
                Position = Position.Center,
                //Size = 100
            };

            var result = await _widgetAppService.Save(widgetDto);

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task CreateManyWidgets_Test()
        {
            // Act

            await CreatePage_Test();

            var pages = await _pageAppService.GetAllAsync(new PagedAndSortedResultRequestDto() { MaxResultCount = 10 });

            var page = pages.Items.FirstOrDefault();

            var widgets = new List<WidgetDto> {
                    new WidgetDto
                    {
                        Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        WidgetType = WidgetType.Paragraph,
                        PageId = page.Id,
                        ParentId = null,
                        Position = Position.Center,
                        SizeType = SizeType._25
                    } ,
                    new WidgetDto
                    {
                        Content = "<p>MRP</p>",
                        WidgetType = WidgetType.Html,
                        PageId = page.Id,
                        ParentId = null,
                        Position = Position.Left,
                        SizeType = SizeType._50
                    }
            };

            await _widgetAppService.SaveList(page.Id, widgets);

            var result = await _widgetAppService.GetAll();

            // Assert
            result.Count().ShouldBeGreaterThan(1);
        }

        [Fact]
        public async Task UpdateWidget_Test()
        {
            // Act

            await CreateWidget_Test();

            var widgets = await _widgetAppService.GetAll();

            var widgetDto = widgets.First();

            var widgetSaveDto = new WidgetDto
            {
                Id = widgetDto.Id,
                PageId = widgetDto.PageId,
                SizeType = SizeType._66
            };

            var resultId = await _widgetAppService.Save(widgetSaveDto);

            var widgetUpdated = await _widgetAppService.Get(resultId);

            // Assert

            widgetUpdated.SizeType.ShouldBe(SizeType._66);
        }
    }
}