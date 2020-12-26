using MRPanel.Domain;
using Abp.Timing;
using System.Collections.Generic;

namespace MRPanel.EntityFrameworkCore.Seed.Host
{
    public class DefaultSiteContentCreator
    {
        private readonly MRPanelDbContext _context;

        public DefaultSiteContentCreator(MRPanelDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateSiteContent();
        }

        private void CreateSiteContent()
        {
            // Create Home Pages
            var homePage = new Page
            {
                IsHomePage = true,
                PageType = PageType.Page,
                Title = "Welcome",
                CreationTime = Clock.Now
            };

            _context.Pages.Add(homePage);
            _context.SaveChanges();

            // Create Widgets For Home Page
            var homePageContentWidget = new Widget
            {
                Page = homePage,
                WidgetType = Domain.Enum.WidgetType.Paragraph,
                Order = 1,
                Position = Domain.Enum.Position.Justify,
                SizeType = Domain.Enum.SizeType._100,
                Content = "<p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.</p>"
            };

            var homePageHolderWidget = new Widget
            {
                Page = homePage,
                WidgetType = Domain.Enum.WidgetType.Container,
                Order = 1,
                Position = Domain.Enum.Position.Justify,
                SizeType = Domain.Enum.SizeType._100
            };

            var homePageLeftWidget = new Widget
            {
                Page = homePage,
                WidgetType = Domain.Enum.WidgetType.Paragraph,
                Order = 1,
                Position = Domain.Enum.Position.Justify,
                SizeType = Domain.Enum.SizeType._50,
                Parent = homePageHolderWidget,
                Content = "<p>Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.</p>"
            };

            var homePageRightWidget = new Widget
            {
                Page = homePage,
                WidgetType = Domain.Enum.WidgetType.Paragraph,
                Order = 1,
                Position = Domain.Enum.Position.Justify,
                SizeType = Domain.Enum.SizeType._50,
                Parent = homePageHolderWidget,
                Content = "<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.</p>"
            };

            _context.Widgets.AddRange(new List<Widget> {
                homePageContentWidget,
                homePageHolderWidget,
                homePageLeftWidget,
                homePageRightWidget });
            _context.SaveChanges();

            // Create About Page
            var aboutPage = new Page
            {
                IsHomePage = false,
                PageType = PageType.Page,
                Title = "About us",
                CreationTime = Clock.Now
            };

            _context.Pages.Add(aboutPage);
            _context.SaveChanges();

            // Create Widgets For About Page
            var AboutPageContentWidget = new Widget
            {
                Page = aboutPage,
                WidgetType = Domain.Enum.WidgetType.Paragraph,
                Order = 1,
                Position = Domain.Enum.Position.Justify,
                SizeType = Domain.Enum.SizeType._100,
                Content = "<h2>Where does it come from?</h2><p>&nbsp;</p><p>Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.</p><p>The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.</p>"
            };

            _context.Widgets.Add(AboutPageContentWidget);
            _context.SaveChanges();

            //Create menu
            var homePageMenu = new Menu
            {
                IsExternal = false,
                PageId = homePage.Id,
                Title = "Home",
                Url = "home"
            };

            var aboutPageMenu = new Menu
            {
                IsExternal = false,
                PageId = aboutPage.Id,
                Title = "About us",
                Url = "about-us"
            };

            var subMenus = new Menu
            {
                IsExternal = false,
                Title = "Sub Menus"
            };

            var sub_1_Menus = new Menu
            {
                IsExternal = true,
                Parent = subMenus,
                Title = "Sub Menus-1",
                Description = "Quisque rutrum. Aenean imperdiet",
                Icon = "ni ni-planet",
                Url = "https://github.com/iPazooki"
            };

            var sub_2_Menus = new Menu
            {
                IsExternal = true,
                Parent = subMenus,
                Title = "Sub Menus-2",
                Description = "Aenean leo ligula, porttitor",
                Icon = "ni ni-spaceship",
                Url = "https://www.linkedin.com/in/pazooki/"
            };

            _context.Menus.AddRange(new List<Menu> {
                homePageMenu ,
                aboutPageMenu,
                subMenus,
                sub_1_Menus,
                sub_2_Menus
            });

            _context.SaveChanges();
        }
    }
}