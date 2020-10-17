using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using MRPanel.Authorization;
using MRPanel.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    [AbpAuthorize(PermissionNames.Pages_Menu)]
    public class MenuAppService : AsyncCrudAppService<Menu, MenuDto, Guid>, IMenuAppService
    {
        private readonly IRepository<Menu, Guid> _repository;
        private readonly IObjectMapper _mapper;

        public MenuAppService(IRepository<Menu, Guid> repository, IObjectMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuDto>> GetAllMenus()
        {
            var menus = await _repository.GetAllListAsync();

            return _mapper.Map<IEnumerable<MenuDto>>(menus);
        }
    }
}