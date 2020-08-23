using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MRPanel.Authorization;
using MRPanel.Domain;
using System;

namespace MRPanel.Services
{
    [AbpAuthorize(PermissionNames.Pages_Pages)]
    public class PageAppService : AsyncCrudAppService<Page, PageDto, Guid>, IPageAppService
    {
        public PageAppService(IRepository<Page, Guid> repository) : base(repository)
        {
        }
    }
}