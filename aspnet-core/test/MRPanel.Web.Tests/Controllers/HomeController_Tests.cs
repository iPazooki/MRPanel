using System.Threading.Tasks;
using MRPanel.Models.TokenAuth;
using MRPanel.Web.Controllers;
using Shouldly;
using Xunit;

namespace MRPanel.Web.Tests.Controllers
{
    public class HomeController_Tests: MRPanelWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}