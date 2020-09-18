using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public interface ISitePageAppService : IApplicationService
    {
        Task<IEnumerable<SitePageDto>> GetAll();
    }
}