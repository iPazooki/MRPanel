using Abp.Application.Services;
using MRPanel.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public interface ISitePageAppService : IApplicationService
    {
        Task<IEnumerable<SitePageDto>> GetAllByPageType(PageType pageType);

        Task<SitePageDto> GetHomePage();
    }
}