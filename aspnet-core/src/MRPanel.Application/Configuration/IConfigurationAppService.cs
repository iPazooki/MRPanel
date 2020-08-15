using System.Threading.Tasks;
using MRPanel.Configuration.Dto;

namespace MRPanel.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
