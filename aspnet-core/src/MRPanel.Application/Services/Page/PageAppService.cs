using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using MRPanel.Authorization;
using MRPanel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPanel.Services
{
    [AbpAuthorize(PermissionNames.Pages_Pages)]
    public class PageAppService : AsyncCrudAppService<Page, PageDto, Guid>, IPageAppService
    {
        private readonly IRepository<Page, Guid> _pageRepository;
        private readonly IObjectMapper _mapper;

        public PageAppService(IRepository<Page, Guid> pageRepository, IObjectMapper mapper) : base(pageRepository)
        {
            _pageRepository = pageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PageDto>> GetAllPages()
        {
            var pages = await _pageRepository.GetAllListAsync(x => x.PageType == PageType.Page);

            return _mapper.Map<IEnumerable<PageDto>>(pages);
        }

        public async Task<IEnumerable<TopPageDto>> GetAllTopPages(int take = 10)
        {
            var pages = await _pageRepository.GetAllIncluding(x => x.Menu).ToListAsync();

            return _mapper.Map<IEnumerable<TopPageDto>>(pages.Take(take));
        }
    }
}