using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MRPanel.Roles.Dto;
using MRPanel.Users.Dto;

namespace MRPanel.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
