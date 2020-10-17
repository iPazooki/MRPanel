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
    [AbpAuthorize(PermissionNames.Pages_Pages)]
    public class PageAppService : AsyncCrudAppService<Page, PageDto, Guid>, IPageAppService
    {
        private readonly IRepository<Page, Guid> _repository;
        private readonly IObjectMapper _mapper;

        public PageAppService(IRepository<Page, Guid> repository, IObjectMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PageDto>> GetAllPages()
        {
            var pages = await _repository.GetAllListAsync(x => x.PageType == PageType.Page);

            return _mapper.Map<IEnumerable<PageDto>>(pages);
        }
    }
}