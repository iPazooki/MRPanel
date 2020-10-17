using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using MRPanel.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    public class SiteMenuAppService : ISiteMenuAppService
    {
        private readonly IRepository<Menu, Guid> _menuRepository;
        private readonly IObjectMapper _mapper;

        public SiteMenuAppService(IRepository<Menu, Guid> menuRepository, IObjectMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SiteMenuDto>> GetAll()
        {
            var menus = await _menuRepository.GetAllListAsync();

            return _mapper.Map<IEnumerable<SiteMenuDto>>(menus);
        }
    }
}