using System.Threading.Tasks;
using Shouldly;
using Xunit;
using MRPanel.Services;
using System.Linq;
using MRPanel.Domain.Enum;
using System.Collections.Generic;
using Abp.Timing;
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

            var pageDto = new PageDto
            {
                Title = "Lorem Ipsum is simply dummy text of the printing and typesetting",
                CreationTime = Clock.Now,
                PageType = Domain.PageType.Page
            };

            var resultPage = await CreatePage(pageDto);

            var widgetDto = new WidgetDto
            {
                Content = "Hello",
                WidgetType = WidgetType.Paragraph,
                PageId = resultPage.Id,
                ParentId = null,
                Position = Position.Center,
                SizeType = SizeType._100,
                Order = 1
            };

            var widgetId = await _widgetAppService.Save(widgetDto);

            var widget = await _widgetAppService.Get(widgetId);

            // Assert
            widget.ShouldNotBeNull();
            widget.Content.ShouldBe("Hello");
            widget.PageId.ShouldBe(resultPage.Id);
        }

        [Fact]
        public async Task CreateManyWidgets_Test()
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

            var widgets = new List<WidgetDto> {
                    new WidgetDto
                    {
                        Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        WidgetType = WidgetType.Paragraph,
                        PageId = resultPage.Id,
                        ParentId = null,
                        Position = Position.Center,
                        SizeType = SizeType._25
                    } ,
                    new WidgetDto
                    {
                        Content = "<p>MRP</p>",
                        WidgetType = WidgetType.Html,
                        PageId = resultPage.Id,
                        ParentId = null,
                        Position = Position.Right,
                        SizeType = SizeType._50
                    }
            };

            await _widgetAppService.SaveList(resultPage.Id, widgets);

            var result = await _widgetAppService.GetAll();

            // Assert
            result.Count().ShouldBeGreaterThan(1);
        }

        [Fact]
        public async Task CreateParentChildWidgets_Test()
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

            var parentWidget = new WidgetDto
            {
                WidgetType = WidgetType.Container,
                PageId = resultPage.Id,
                ParentId = null,
                Position = Position.Right,
                SizeType = SizeType._50
            };

            var parentWidgetId = await _widgetAppService.Save(parentWidget);

            parentWidget = await _widgetAppService.Get(parentWidgetId);

            var widgets = new List<WidgetDto> {
                    parentWidget,
                    new WidgetDto
                    {
                        Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        WidgetType = WidgetType.Paragraph,
                        PageId = resultPage.Id,
                        ParentId = parentWidget.Id,
                        Position = Position.Center,
                        SizeType = SizeType._25
                    } ,
                    new WidgetDto
                    {
                        Content = "<p>MRP</p>",
                        WidgetType = WidgetType.Html,
                        PageId = resultPage.Id,
                        ParentId =  parentWidget.Id,
                        Position = Position.Right,
                        SizeType = SizeType._50
                    }
            };

            await _widgetAppService.SaveList(resultPage.Id, widgets);

            var result = await _widgetAppService.GetAll();

            // Assert
            result.Count().ShouldBeGreaterThan(1);

            result.Count(x => x.ParentId != null).ShouldBe(2);
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

        [Fact]
        public async Task DeleteWidget_Test()
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

            var widgetDto = new WidgetDto
            {
                Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                WidgetType = WidgetType.Paragraph,
                PageId = resultPage.Id,
                ParentId = null,
                Position = Position.Center,
                SizeType = SizeType._100,
                Order = 1
            };

            var widgetId = await _widgetAppService.Save(widgetDto);

            await _widgetAppService.Delete(widgetId);

            // Asseert

            (await _widgetAppService.GetAll()).Count().ShouldBe(0);
        }

        [Fact]
        public async Task DeleteWidgetList_Test()
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

            var parentWidget = new WidgetDto
            {
                WidgetType = WidgetType.Container,
                PageId = resultPage.Id,
                ParentId = null,
                Position = Position.Right,
                SizeType = SizeType._50
            };

            var parentWidgetId = await _widgetAppService.Save(parentWidget);

            parentWidget = await _widgetAppService.Get(parentWidgetId);

            var widgets = new List<WidgetDto> {
                    parentWidget,
                    new WidgetDto
                    {
                        Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        WidgetType = WidgetType.Paragraph,
                        PageId = resultPage.Id,
                        ParentId = parentWidget.Id,
                        Position = Position.Center,
                        SizeType = SizeType._25
                    } ,
                    new WidgetDto
                    {
                        Content = "<p>MRP</p>",
                        WidgetType = WidgetType.Html,
                        PageId = resultPage.Id,
                        ParentId =  parentWidget.Id,
                        Position = Position.Right,
                        SizeType = SizeType._50
                    }
            };

            await _widgetAppService.SaveList(resultPage.Id, widgets);

            await _widgetAppService.Delete(parentWidget.Id.Value);

            // Asseert

            (await _widgetAppService.GetAll()).Count().ShouldBe(0);
        }
    }
}