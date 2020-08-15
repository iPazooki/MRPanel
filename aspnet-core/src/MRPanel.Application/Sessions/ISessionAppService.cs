using System.Threading.Tasks;
using Abp.Application.Services;
using MRPanel.Sessions.Dto;

namespace MRPanel.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
