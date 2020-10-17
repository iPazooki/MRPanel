using Abp.Application.Services;
using MRPanel.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public interface ISiteMenuAppService : IApplicationService
    {
        Task<IEnumerable<SiteMenuDto>> GetAll();
    }
}